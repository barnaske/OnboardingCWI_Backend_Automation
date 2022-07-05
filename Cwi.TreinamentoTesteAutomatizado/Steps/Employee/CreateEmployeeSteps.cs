using Cwi.TreinamentoTesteAutomatizado.Controllers;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.TreinamentoTesteAutomatizado.Steps.Employee
{
    [Binding]
    [Scope(Tag = "CreateEmployee")]
    public class CreateEmployeeSteps
    {
        private readonly HttpRequestController HttpRequestController;

        public CreateEmployeeSteps(HttpRequestController httpRequestController)
        {
            HttpRequestController = httpRequestController;
        }

        [Given(@"que seja solicitado a criação de um novo funcionário")]
        public async Task GivenQueSejaSolicitadoACriacaoDeUmNovoFuncionario()
        {
            HttpRequestController.AddJsonBody(new { Name = "Funcionario 1", Email = "funcionario1@empresa.com" });
            
            await HttpRequestController.SendAsync("v1/employees", "post");
        }

        [Given(@"que seja solicitado a criação de um novo funcionário sem o preenchimento dos campos obrigatórios")]
        public async Task GivenQueSejaSolicitadoACriacaoDeUmNovoFuncionarioSemOPreenchimentoDosCamposObrigatorios()
        {
            HttpRequestController.AddJsonBody(new { });

            await HttpRequestController.SendAsync("v1/employees", "post");
        }


        [Then(@"o funcionário não será cadastrado")]
        public void ThenOFuncionarioNaoSeraCadastrado()
        {
            Assert.AreNotEqual(HttpStatusCode.Created, HttpRequestController.GetResponseHttpStatusCode());
        }


        [Then(@"o funcionário será cadastrado")]
        public void ThenOFuncionarioSeraCadastrado()
        {
            Assert.AreEqual(HttpStatusCode.Created, HttpRequestController.GetResponseHttpStatusCode());
        }


        [Then(@"será retornado uma mensagem de falha de autenticação")]
        public void ThenSeraRetornadoUmaMensagemDeFalhaDeAutenticacao()
        {
            Assert.AreEqual(HttpStatusCode.Unauthorized, HttpRequestController.GetResponseHttpStatusCode());
        }

        [Then(@"será retornado uma mensagem de falha de preenchimento de campos obrigatórios")]
        public void ThenSeraRetornadoUmaMensagemDeFalhaDePreenchimentoDeCamposObrigatorios()
        {
            Assert.AreEqual(HttpStatusCode.BadRequest, HttpRequestController.GetResponseHttpStatusCode());
        }

    }
}