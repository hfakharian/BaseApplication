using Application.Wrappers;
using Domain.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Request.UserUnitRole.Queries
{
    public class GetUserUnitRolesQueryRequest : BaseAuthenticatedRequestWrapper<List<UserUnitRoleDTO>>
    {
        public string? SearchWord { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
