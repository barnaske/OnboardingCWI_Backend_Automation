using System.Threading.Tasks;
using Cwi.TreinamentoTesteAutomatizado.Controllers;
using TechTalk.SpecFlow;

namespace Cwi.TreinamentoTesteAutomatizado.Steps
{
    [Binding]
    public class GetCompaniesSteps
    {
        private HttpRequestController httpRequestController;
        
        [When(@"seja realizada um requisição com o método '(.*)' para o endpoint '(.*)'")]
        public async Task WhenSejaRealizadaUmRequisicaoComOMetodoParaOEndpoint(string httpMethodName, string endpoint)
        {
            await httpRequestController.SendAsync(endpoint, httpMethodName);
        }
    }
}