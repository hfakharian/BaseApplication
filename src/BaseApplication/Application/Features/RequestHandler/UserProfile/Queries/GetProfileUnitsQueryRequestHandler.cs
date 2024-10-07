using Application.Features.Request.UserProfile.Queries;
using Application.Features.Request.UserUnitRole.Queries;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RequestHandler.UserProfile.Queries
{
    public class GetProfileUnitsQueryRequestHandler : IRequestHandlerWrapper<GetProfileUnitsQueryRequest, List<UserUnitRoleDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProfileUnitsQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<List<UserUnitRoleDTO>>> Handle(GetProfileUnitsQueryRequest request, CancellationToken cancellationToken)
        {
            var userUnitRoles = await unitOfWork.UserUnitRoleRepository.GetByExpression(
               w => w.UserID == request.CurrentUser.AuthUserId,
               orderBy: null,
               includeProperties: "Unit,Role");

            var UserUnitRoleDTOs = mapper.Map<IEnumerable<Domain.Entities.User.UserUnitRole>, List<UserUnitRoleDTO>>(userUnitRoles);

            return new CollectionResult<List<UserUnitRoleDTO>>(true, true, UserUnitRoleDTOs);
        }
    }
}
