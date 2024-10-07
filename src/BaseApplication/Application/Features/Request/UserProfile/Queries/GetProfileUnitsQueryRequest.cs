using Application.Wrappers;
using Domain.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Request.UserProfile.Queries
{
    public class GetProfileUnitsQueryRequest : BaseAuthenticatedRequestWrapper<List<UserUnitRoleDTO>>
    {
    }
}
