using Application.Features.Request.Menu.Queries;
using Asp.Versioning;
using Domain.DataTransferObjects.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MenuController : BaseAuthController
    {

        private readonly IMediator mediator;

        public MenuController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // List
        [AllowAnonymous]
        [Authorize]
        [HttpGet("GetMenus")]
        public async Task<IActionResult> GetMenus()
        {
            var data = await mediator.Send(new GetMenusQueryRequest { });
            return Ok(data);
        }

    }
}
