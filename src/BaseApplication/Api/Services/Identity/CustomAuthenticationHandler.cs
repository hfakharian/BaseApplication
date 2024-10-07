using Application.Security;
using Application.Security.AuthenticationRole;
using Domain.Entities.User;
using Domain.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Api.Services.Identity
{
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
    {
        private readonly JwtSettings jwtSettings;
        private readonly IServiceAuthenticationRole serviceAuthenticationRole;

        public CustomAuthenticationHandler(IOptionsMonitor<CustomAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            JwtSettings jwtSettings,
            IServiceAuthenticationRole serviceAuthenticationRole
            ) : base(options, logger, encoder)
        {
            this.jwtSettings = jwtSettings;
            this.serviceAuthenticationRole = serviceAuthenticationRole;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(CustomAuthenticationOptions.TokenHeaderName))
                return await Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

            string unitKey = Request.Headers[CustomAuthenticationOptions.UnitHeaderName].ToString() ?? string.Empty;
            string tokenKey = Request.Headers[CustomAuthenticationOptions.TokenHeaderName].ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(tokenKey))
                return await Task.FromResult(AuthenticateResult.NoResult());

            if (!tokenKey.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
                return await Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

            tokenKey = tokenKey.Substring("bearer".Length).Trim().Replace(" ", "+");

            if (string.IsNullOrEmpty(tokenKey))
                return await Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

            try
            {
                var isValidToken = JwtProvider.JwtValidator(tokenKey, jwtSettings, out JwtSecurityToken jwt);

                if (isValidToken)
                {
                    var claims = jwt.Claims.ToList();

                    claims.Add(new Claim("unit", unitKey));

                    claims = await serviceAuthenticationRole.GetClaimRoles(claims);

                    var identity = new ClaimsIdentity(claims, this.Scheme.Name);
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    AuthenticationTicket ticket = new AuthenticationTicket(claimsPrincipal, this.Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return await Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
                }

            }
            catch (Exception ex)
            {
                return await Task.FromResult(AuthenticateResult.Fail(ex.Message));
            }
        }
    }
}
