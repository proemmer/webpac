using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;

namespace webpac.Auth
{
    public class TokenAuthOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
    }
}
