using Application.Features.Request.Account;
using Asp.Versioning;
using Contract.Services.Captcha;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.General;
using Domain.DataTransferObjects.User;
using Domain.DataTransferObjects.User.SignIn;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility.Services.Captcha;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccountController : BaseAuthController
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("Captcha")]
        public IActionResult Captcha([FromServices] ICaptchaService captchaService)
        {
            return Ok(new CollectionResult<CaptchaDTO>(false, true, captchaService.GenerateEncryptedCaptcha()));
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInDTO body)
        {
            var user = await mediator.Send(new SignInQueryRequest { User = body });
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserDTO body)
        {
            var user = await mediator.Send(new SignUpQueryRequest { User = body });
            return Ok(user);
        }

        [Authorize]
        [HttpPost("SignOut")]
        public IActionResult SignOut()
        {
            return Ok(new CollectionResult<bool>(false, true, true));
        }
    }
}
