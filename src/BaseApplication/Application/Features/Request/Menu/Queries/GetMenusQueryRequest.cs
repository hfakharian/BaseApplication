using Application.Wrappers;
using Domain.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Request.Menu.Queries
{
    public class GetMenusQueryRequest : BaseAuthenticatedRequestWrapper<List<MenuDTO>>
    {
    }
}
