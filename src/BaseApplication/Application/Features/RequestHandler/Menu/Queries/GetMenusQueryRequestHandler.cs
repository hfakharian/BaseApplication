using Application.Features.Request.Menu.Queries;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Entities.User;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RequestHandler.Menu.Queries
{
    public class GetMenusQueryRequestHandler : IRequestHandlerWrapper<GetMenusQueryRequest, List<MenuDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetMenusQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<List<MenuDTO>>> Handle(GetMenusQueryRequest request, CancellationToken cancellationToken)
        {
            var menus = new List<MenuDTO>();

            if (request.CurrentUser.IsAuthenticated)
            {
                if (request.CurrentUser.AuthUnitId != 0)
                {
                    var menu = await unitOfWork.MenuRepository.GetByExpression(
                    w => w.Roles
                    .Any(r => r.UserUnitRoles
                    .Any(uur => uur.UnitID == request.CurrentUser.AuthUnitId && uur.UserID == request.CurrentUser.AuthUserId)),
                    orderBy: sort => sort.OrderBy(o => o.Sort));

                    var MenuDTOs = mapper.Map<IEnumerable<Domain.Entities.User.Menu>, List<MenuDTO>>(menu);

                    return new CollectionResult<List<MenuDTO>>(true, true, MenuDTOs);
                }
                else
                {
                    var menu = await unitOfWork.MenuRepository.GetByExpression(
                    w => w.Roles
                    .Any(r => r.ID == 1),
                    orderBy: sort => sort.OrderBy(o => o.Sort));

                    var MenuDTOs = mapper.Map<IEnumerable<Domain.Entities.User.Menu>, List<MenuDTO>>(menu);

                    return new CollectionResult<List<MenuDTO>>(true, true, MenuDTOs);
                }
            }
            else
            {
                var menu = await unitOfWork.MenuRepository.GetByExpression(
                    w => !w.Roles
                    .Any(r => true),
                    orderBy: sort => sort.OrderBy(o => o.Sort));

                var MenuDTOs = mapper.Map<IEnumerable<Domain.Entities.User.Menu>, List<MenuDTO>>(menu);

                return new CollectionResult<List<MenuDTO>>(false, true, MenuDTOs);
            }

        }
    }
}
