using System;

namespace Cwi.TreinamentoTesteAutomatizado.Models
{
    public class AuthenticationResponse
    {

        public string AccessToken { get; set; }

        public DateTime Created{ get; set; }

        public DateTime Expiration{ get; set; }

    }
}
