using Application.Features.Request.UserUnitRole.Commands;
using Application.Features.Request.UserUnitRole.Queries;
using Asp.Versioning;
using Domain.DataTransferObjects.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserUnitRoleController : BaseAuthController
    {
        private readonly IMediator mediator;

        public UserUnitRoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // List User of Unit
        [Authorize(Roles = "UnitAdmin")]
        [HttpGet("GetUserUnitRoles")]
        public async Task<IActionResult> GetUserUnitRoles(string? searchWord ,int skip, int take)
        {
            var UserUnitRoles = await mediator.Send(new GetUserUnitRolesQueryRequest { SearchWord = searchWord,  Skip = skip, Take = take });
            return Ok(UserUnitRoles);
        }

        // Single User of Unit
        [Authorize(Roles = "UnitAdmin")]
        [HttpGet("GetUserUnitRole")]
        public async Task<IActionResult> GetUserUnitRole( int userID)
        {
            var UserUnitRole = await mediator.Send(new GetUserUnitRoleQueryRequest {  UserID = userID });
            return Ok(UserUnitRole);
        }

        // Update User of Unit
        [Authorize(Roles = "UnitAdmin")]
        [HttpPut("UpdateUserUnitRole")]
        public async Task<IActionResult> UpdateUserUnitRole([FromBody] UserUnitRoleDTO body)
        {
            var UserUnitRole = await mediator.Send(new UpdateUserUnitRoleCommandRequest { UserUnitRole = body });
            return Ok(UserUnitRole);
        }

        // Create User of Unit
        [Authorize(Roles = "UnitAdmin")]
        [HttpPost("CreateUserUnitRole")]
        public async Task<IActionResult> CreateUserUnitRole([FromBody] UserUnitRoleDTO body)
        {
            var UserUnitRole = await mediator.Send(new UpdateUserUnitRoleCommandRequest { UserUnitRole = body });
            return Ok(UserUnitRole);
        }

        // Delete User of Unit
        [Authorize(Roles = "UnitAdmin")]
        [HttpDelete("DeleteUserUnitRole")]
        public async Task<IActionResult> DeleteUserUnitRole( int userID)
        {
            var UserUnitRole = await mediator.Send(new DeleteUserUnitRoleCommandRequest {  UserID = userID });
            return Ok(UserUnitRole);
        }

        // Modify User of Unit
        [Authorize(Roles = "UnitAdmin")]
        [HttpPatch("ModifyUserUnitRole")]
        public async Task<IActionResult> ModifyUserUnitRole(int userID)
        {
            var UserUnitRole = await mediator.Send(new ModifyUserUnitRoleCommandRequest { UserID = userID });
            return Ok(UserUnitRole);
        }
    }
}
