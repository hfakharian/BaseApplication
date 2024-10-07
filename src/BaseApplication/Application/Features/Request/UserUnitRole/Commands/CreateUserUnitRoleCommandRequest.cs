using Application.Wrappers;
using Domain.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Request.UserUnitRole.Commands
{
    public class CreateUserUnitRoleCommandRequest : BaseAuthenticatedRequestWrapper<UserUnitRoleDTO>
    {
        public UserUnitRoleDTO UserUnitRole { get; set; }
    }
}
