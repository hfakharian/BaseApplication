using Microsoft.AspNetCore.Authentication;

namespace Api.Services.Identity
{
    public class CustomAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScemeName = "CustomAuthJwt";
        public const string TokenHeaderName = "Authorization";
        public const string UnitHeaderName = "Unitkey";
    }
}
