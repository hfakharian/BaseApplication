using Application.Features.Request.UnitProfile.Commands;
using Application.Features.Request.UnitProfile.Queries;
using Asp.Versioning;
using Domain.DataTransferObjects.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UnitProfileController : BaseAuthController
    {

        private readonly IMediator mediator;

        public UnitProfileController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // List Unit
        [Authorize(Roles = "UnitAdmin")]
        [HttpGet("GetProfileUnit")]
        public async Task<IActionResult> GetProfileUnit()
        {
            var user = await mediator.Send(new GetProfileUnitQueryRequest { });
            return Ok(user);
        }

        // List User
        [Authorize(Roles = "UnitAdmin")]
        [HttpPost("UpdateProfileUnit")]
        public async Task<IActionResult> UpdateProfileUnit([FromBody] UnitDTO body)
        {
            var user = await mediator.Send(new UpdateProfileUnitCommandRequest { Unit = body });
            return Ok(user);
        }

    }
}
