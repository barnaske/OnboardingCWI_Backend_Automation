using Cwi.TreinamentoTesteAutomatizado.Controllers;
using Cwi.TreinamentoTesteAutomatizado.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cwi.TreinamentoTesteAutomatizado.Steps.Common
{
    [Binding]
    public class AuthenticationSteps
    {
        private readonly HttpRequestController HttpRequestController;
        private readonly IConfiguration Configuration;

        public AuthenticationSteps(HttpRequestController httpRequestController, IConfiguration configuration)
        {
            HttpRequestController = httpRequestController;
            Configuration = configuration;
        }

        [Given(@"que o usuário não esteja autenticado")]
        public void GivenQueOUsuarioNaoEstejaAutenticado()
        {
            HttpRequestController.RemoveHeader("Authorization");
        }

        [Given(@"que o usuário esteja autenticado")]
        public async Task GivenQueOUsuarioEstejaAutenticado()
        {
            HttpRequestController.AddJsonBody(new { username = Configuration["Authentication:username"], password = Configuration["Authentication:password"] });

            await HttpRequestController.SendAsync("v1/public/auth", "POST");

            Assert.AreEqual(HttpStatusCode.OK, HttpRequestController.GetResponseHttpStatusCode());

            var authenticationResponse = await HttpRequestController.GetTypedResponseBody<AuthenticationResponse>();

            HttpRequestController.AddHeader("Authorization", $"Bearer { authenticationResponse.AccessToken }");

        }
    }
}
