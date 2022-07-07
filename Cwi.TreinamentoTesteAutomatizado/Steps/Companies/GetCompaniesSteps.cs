using System.Threading.Tasks;
using Cwi.TreinamentoTesteAutomatizado.Controllers;
using Dynamitey.DynamicObjects;
using TechTalk.SpecFlow;

namespace Cwi.TreinamentoTesteAutomatizado.Steps
{
    [Binding]
    public class GetCompaniesSteps
    {
        private readonly HttpRequestController HttpRequestController;

        public GetCompaniesSteps(HttpRequestController httpRequestController)
        {
            HttpRequestController = httpRequestController;
        }
            
        [When(@"seja realizada um requisição com o método '(.*)' para o endpoint '(.*)'")]
        public async Task WhenSejaRealizadaUmRequisicaoComOMetodoParaOEndpoint(string httpMethodName, string endpoint)
        {
            await HttpRequestController.SendAsync(endpoint, httpMethodName);
        }
    }
}