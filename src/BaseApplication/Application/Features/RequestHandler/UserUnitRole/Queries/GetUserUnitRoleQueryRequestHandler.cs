using Application.Features.Request.UserUnitRole.Queries;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Entities.User;
using Domain.Entities.User.Enum;
using Utility.Services.Enum;

namespace Application.Features.RequestHandler.UserUnitRole.Queries
{
    public class GetUserUnitRoleQueryRequestHandler : IRequestHandlerWrapper<GetUserUnitRoleQueryRequest, UserUnitRoleDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserUnitRoleQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UserUnitRoleDTO>> Handle(GetUserUnitRoleQueryRequest request, CancellationToken cancellationToken)
        {
            UserUnitRoleDTO UserUnitRoleDTO;
            var userUnitRole = await unitOfWork.UserUnitRoleRepository.FindByExpression(w => w.UnitID == request.CurrentUser.AuthUnitId && w.UserID == request.UserID, "User,Role");

            if (userUnitRole != null)
            {
                UserUnitRoleDTO = mapper.Map<Domain.Entities.User.UserUnitRole, UserUnitRoleDTO>(userUnitRole);
            }
            else
            {
                userUnitRole = new Domain.Entities.User.UserUnitRole
                {
                    UnitID = request.CurrentUser.AuthUnitId,
                    UserID = 0,
                    RoleID = 0,
                    IsAccepted = false,
                    User = new Domain.Entities.User.User(),
                };

                UserUnitRoleDTO = mapper.Map<Domain.Entities.User.UserUnitRole, UserUnitRoleDTO>(userUnitRole);
            }

            var roles = await unitOfWork.RoleRepository.GetByExpression(w => w.RoleType == Domain.Entities.User.Enum.RoleType.Public);

            UserUnitRoleDTO.Roles = mapper.Map<IEnumerable<Domain.Entities.User.Role>, List<RoleDTO>>(roles);

            UserUnitRoleDTO.User!.UserTypeModels = EnumConvertor.EnumToListModel<UserType>();
            UserUnitRoleDTO.User!.UserStatusModels = EnumConvertor.EnumToListModel<UserStatus>();
            UserUnitRoleDTO.User!.GenderModels = EnumConvertor.EnumToListModel<Gender>();

            return new CollectionResult<UserUnitRoleDTO>(true, true, UserUnitRoleDTO);
        }
    }
}
