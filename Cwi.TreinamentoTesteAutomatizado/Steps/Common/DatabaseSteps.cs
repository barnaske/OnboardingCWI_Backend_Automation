using Cwi.TreinamentoTesteAutomatizado.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Cwi.TreinamentoTesteAutomatizado.Steps.Common
{
    [Binding]
    public class DatabaseSteps
    {
        public readonly PostgreDatabaseController PostgreDatabaseController;
        public DatabaseSteps(PostgreDatabaseController postgreDatabaseController)
        {
            PostgreDatabaseController = postgreDatabaseController;
        }

        [Given(@"que a base de dados esteja limpa")]
        public async Task GivenQueABaseDeDadosEstejaLimpa()
        {
            await PostgreDatabaseController.ClearDatabase();
        }

        [Then(@"o registro estará disponível na tabela '(.*)' da base de dados")]
        public async Task ThenORegistroEstaraDisponivelNaTabeleDaBaseDeDados(string tableName, Table table)
        {
            var currentItems = await PostgreDatabaseController.SelectFrom(tableName, table);

            Assert.NotZero(currentItems.Count(), $"Não forma encontrados registros na table {tableName}.");

            var actualJsonResponse = JsonConvert.SerializeObject(currentItems);
            var expectedJsonResponse = JsonConvert.SerializeObject(table.CreateDynamicSet()).Replace("'", "");

            Assert.IsTrue(JToken.DeepEquals(JToken.Parse(actualJsonResponse), JToken.Parse(expectedJsonResponse)), $"Conteúdo atual do retorno \n{actualJsonResponse} diferente do esperado \n{expectedJsonResponse}");
        }

    }
}
