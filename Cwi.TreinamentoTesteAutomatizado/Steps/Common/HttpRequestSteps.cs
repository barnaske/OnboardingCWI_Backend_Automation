using Cwi.TreinamentoTesteAutomatizado.Controllers;
using Cwi.TreinamentoTesteAutomatizado.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Cwi.TreinamentoTesteAutomatizado.Steps.Common
{
    [Binding]
    public class HttpRequestSteps
    {

        private readonly HttpRequestController HttpRequestController;
        private readonly IConfiguration Configuration;

        public HttpRequestSteps(HttpRequestController httpRequestController, IConfiguration configuration)
        {
            HttpRequestController = httpRequestController;
            Configuration = configuration;
        }

        [Given(@"seja feita uma chamado do tipo '(.*)' para o endpoint '(.*)' com o corpo da requisição")]
        public async Task GivenSejaFeitaUmaChamadoDoTipoParaOEndpointComOCorpoDaRequisicao(string httpMethodName, string endpoint, string jsonBody)
        {
            HttpRequestController.AddJsonBody(jsonBody);

            await HttpRequestController.SendAsync(endpoint, httpMethodName);
       }

        [Then(@"com o usuário autenticado, seja feita uma chamado do tipo '([^']*)' para o endpoint '([^']*)', seu retorno será")]
        public async Task ThenComOUsuarioAutenticadoSejaFeitaUmaChamadoDoTipoParaOEndpointSeuRetornoSera(string httpMethodName, string endpoint, string jsonResponse)
        {
            HttpRequestController.AddJsonBody(new { username = Configuration["Authentication:username"], password = Configuration["Authentication:password"] });

            await HttpRequestController.SendAsync("v1/public/auth", "POST");

            Assert.AreEqual(HttpStatusCode.OK, HttpRequestController.GetResponseHttpStatusCode());

            var authenticationResponse = await HttpRequestController.GetTypedResponseBody<AuthenticationResponse>();

            HttpRequestController.AddHeader("Authorization", $"Bearer {authenticationResponse.AccessToken}");

            await HttpRequestController.SendAsync(endpoint, httpMethodName);

            var responseContent = await HttpRequestController.GetResponseBodyContent();

            Assert.AreEqual(jsonResponse, responseContent);
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
