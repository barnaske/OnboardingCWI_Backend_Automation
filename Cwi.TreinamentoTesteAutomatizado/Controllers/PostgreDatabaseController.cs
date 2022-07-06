using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.TreinamentoTesteAutomatizado.Controllers
{
    public class PostgreDatabaseController
    {

        private readonly NpgsqlConnection Connection;

        public PostgreDatabaseController(NpgsqlConnection connection)
        {
            try
            {
                Connection = connection;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível abrir a conexão com a base de dados.", e);
            }

        }

        public async Task ClearDatabase(string schema = "public")
        {
            var query = $@"DO
                           $$
                           DECLARE
                               stmt VARCHAR;
                               databaseschema VARCHAR:= '{schema}';
                           BEGIN
                               SELECT 'truncate ' || string_agg(format('%I.%I', schemaname, tablename), ',')
                               INTO stmt
                               FROM pg_tables
                               WHERE schemaname = databaseschema;
                               
                               EXECUTE stmt || ' RESTART IDENTITY';
                           END;
                           $$";

            await Connection.ExecuteAsync(query);
        }

        public async Task InsertInto(string tableName, Table table)
        {
            var insertColumns = string.Join(",", GetColumnsToInsert(table));

            var values = string.Join(",", GetValuesToInsert(table));

            var insertQuery = $"INSERT INTO {tableName} ({insertColumns}) VALUES ({values});";

            await Connection.ExecuteAsync(insertQuery);
        }

        public async Task<IEnumerable<object>> SelectFrom(string tableName, Table table)
        {
            var selectColumns = string.Join(",",GetColumnsForSelect(table));
            //a função string.Join concatena o retorno "Id as Id Name as Name" com vírgulas, virando "Id as "Id", Name as "Name", ..."
            var filterConditions = string.Join(" OR ", GetFilterConditions(table));

            var query = $"SELECT {selectColumns} FROM {tableName} WHERE {filterConditions}";

            return await Connection.QueryAsync(query);
        }

        private string[] GetColumnsToInsert(Table table)
        {
            return table.Header.ToArray();
        }

        private string[] GetValuesToInsert(Table table)
        {
            return table.Rows.Select(x => string.Join(",",x.Values)).ToArray();
        }

        private string[] GetColumnsForSelect(Table table)
        {
            return table.Header.Select(x => $"{x} AS \"{x}\"").ToArray();
            // isso faz com que o retorno original (Id, Name, Email, Active) seja formatado para => Id as "Id" Name as "Name"...
        }

        private string[] GetFilterConditions(Table table)
        {
            List<String> filters = new List<string>();

            for (int row = 0; row < table.Rows.Count; row++)
            {
                var rowConditions = new List<string>();

                for (int header = 0; header < table.Header.Count; header++)
                {
                    string column = table.Header.ElementAt(header);
                    string value = table.Rows[row][header];

                    rowConditions.Add($"{column} = {value}");
                }

                filters.Add($"({string.Join(" AND ", rowConditions)})");
            }

            return filters.ToArray();
        }
    }
}
