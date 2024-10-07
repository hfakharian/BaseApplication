using Api.Extensions;
using Contract.Services.Security;
using Microsoft.AspNetCore.Http.Features;
using System.Security.Claims;
using Utility.Extensions;

namespace Api.Services.Security
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor accessor)
        {
            var context = accessor.HttpContext;
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            IEnumerable<Claim> Claims = context.User.Claims;

            if (Claims.Count() > 0)
            {
                IsAuthenticated = true;
                AuthTokenId = Claims.FirstOrDefault(q => q.Type.Equals("jti"))?.Value.ToGuid() ?? Guid.Empty;
                AuthUnitId = (string.IsNullOrEmpty(Claims.FirstOrDefault(q => q.Type.Equals("unit"))?.Value) ? 0 : Claims.FirstOrDefault(q => q.Type.Equals("unit"))?.Value.ToInt32() ?? 0);
                AuthUserId = Claims.FirstOrDefault(q => q.Type.Equals("user"))?.Value.ToInt32() ?? 0;
                AuthUserName = Claims.FirstOrDefault(q => q.Type.Equals("username"))?.Value.ToString() ?? string.Empty;
            }
            else
            {
                IsAuthenticated= false;
                AuthTokenId = Guid.Empty;
                AuthUnitId = 0;
                AuthUserId = 0;
                AuthUserName = string.Empty;
            }

            ClientIpAddress = context.IPAddress() ?? "";
            ServerIpAddress = context.GetServerVariable("LOCAL_ADDR") ?? "";
        }
        public bool IsAuthenticated { get; init; }
        public Guid AuthTokenId { get; init; }
        public int AuthUserId { get; init; }
        public int AuthUnitId { get; init; }
        public string AuthUserName { get; init; }
        public string ClientIpAddress { get; init; }
        public string ServerIpAddress { get; init; }
    }
}
