using Cwi.TreinamentoTesteAutomatizado.Controllers;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.TreinamentoTesteAutomatizado.Steps.Common
{
    [Binding]
    public class HttpRequestSteps
    {

        private readonly HttpRequestController HttpRequestController;

        public HttpRequestSteps(HttpRequestController httpRequestController)
        {
            HttpRequestController = httpRequestController;
        }

        [Given(@"seja feita uma chamado do tipo '(.*)' para o endpoint '(.*)' com o corpo da requisição")]
        public async Task GivenSejaFeitaUmaChamadoDoTipoParaOEndpointComOCorpoDaRequisicao(string httpMethodName, string endpoint, string jsonBody)
        {
            HttpRequestController.AddJsonBody(jsonBody);

            await HttpRequestController.SendAsync(endpoint, httpMethodName);
        }

        [Given(@"seja feita uma chamado do tipo '(.*)' para o endpoint '(.*)'")]
        public async Task GivenSejaFeitaUmaChamadoDoTipoParaOEndpoint(string httpMethodName, string endpoint)
        {
            await HttpRequestController.SendAsync(endpoint, httpMethodName);
        }


        [Then(@"o código de retorno será '(.*)'")]
        public void ThenOCodigoDeRetornoSera(int httpStatusCode)
        {
            Assert.AreEqual(httpStatusCode, (int)HttpRequestController.GetResponseHttpStatusCode());
        }

    }
}
