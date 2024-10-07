using Api.Services.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize(AuthenticationSchemes = CustomAuthenticationOptions.DefaultScemeName)]
    public abstract class BaseAuthController : BaseApiController
    {
    }
}
