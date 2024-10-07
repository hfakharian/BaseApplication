using Application.Features.Request.UserProfile.Commands;
using Application.Features.Request.UserProfile.Queries;
using Asp.Versioning;
using Domain.DataTransferObjects.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserProfileController : BaseAuthController
    {

        private readonly IMediator mediator;

        public UserProfileController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // List Unit
        [Authorize(Roles = "User")]
        [HttpGet("GetProfileUnits")]
        public async Task<IActionResult> GetProfileUnits()
        {
            var user = await mediator.Send(new GetProfileUnitsQueryRequest { });
            return Ok(user);
        }

        // List User
        [Authorize(Roles = "User")]
        [HttpGet("GetProfileUser")]
        public async Task<IActionResult> GetProfileUser()
        {
            var user = await mediator.Send(new GetProfileUserQueryRequest { });
            return Ok(user);
        }

        // List User
        [Authorize(Roles = "User")]
        [HttpPost("UpdateProfileUser")]
        public async Task<IActionResult> UpdateProfileUser([FromBody] UserDTO body)
        {
            var user = await mediator.Send(new UpdateProfileUserCommandRequest { User = body });
            return Ok(user);
        }

        // List User
        [Authorize(Roles = "User")]
        [HttpPost("UpdateProfileUserPassword")]
        public async Task<IActionResult> UpdateProfileUserPassword([FromBody] UserPasswordDTO body)
        {
            var user = await mediator.Send(new UpdateProfileUserPasswordCommandRequest { UserPassword = body });
            return Ok(user);
        }

    }
}
