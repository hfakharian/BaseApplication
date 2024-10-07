using Application.Features.Request.UserUnitRole.Queries;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;

namespace Application.Features.RequestHandler.UserUnitRole.Queries
{
    public class GetUserUnitRolesQueryRequestHandler : IRequestHandlerWrapper<GetUserUnitRolesQueryRequest, List<UserUnitRoleDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserUnitRolesQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<List<UserUnitRoleDTO>>> Handle(GetUserUnitRolesQueryRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.SearchWord))
                request.SearchWord = string.Empty;

            var userUnitRoles = await unitOfWork.UserUnitRoleRepository.GetByExpression(
                w => w.UnitID == request.CurrentUser.AuthUnitId && (w.User.Username.Contains(request.SearchWord)),
                orderBy: null,
                includeProperties: "User,Role",
                skip: request.Skip,
                take: request.Take);

            var UserUnitRoleDTOs = mapper.Map<IEnumerable<Domain.Entities.User.UserUnitRole>, List<UserUnitRoleDTO>>(userUnitRoles);

            return new CollectionResult<List<UserUnitRoleDTO>>(true, true, UserUnitRoleDTOs);
        }
    }
}
