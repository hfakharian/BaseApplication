using Application.Features.Request.UserUnitRole.Commands;
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
using Utility.Helper;

namespace Application.Features.RequestHandler.UserUnitRole.Commands
{
    public class UpdateUserUnitRoleCommandRequestHandler : IRequestHandlerWrapper<UpdateUserUnitRoleCommandRequest, UserUnitRoleDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateUserUnitRoleCommandRequestHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UserUnitRoleDTO>> Handle(UpdateUserUnitRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var userUnitRole = await unitOfWork.UserUnitRoleRepository.FindByExpression(w => w.UnitID == request.CurrentUser.AuthUnitId && w.UserID == request.UserUnitRole.UserID);

            if (userUnitRole is null)
                return new CollectionResult<UserUnitRoleDTO>(false, false,
                    UtilityHelper.AddErrorToCollectionResultMessage("Update_UserUnitRole_Null"));


            if (request.CurrentUser.AuthUserId != request.UserUnitRole.UserID)
            {
                if (userUnitRole.RoleID != request.UserUnitRole.RoleID)
                {
                    await unitOfWork.UserUnitRoleRepository.Delete(userUnitRole);

                    await unitOfWork.UserUnitRoleRepository.Create(new Domain.Entities.User.UserUnitRole
                    {
                        UnitID = request.CurrentUser.AuthUnitId,
                        UserID = request.UserUnitRole.UserID ?? 0,
                        RoleID = request.UserUnitRole.RoleID ?? 0,
                        IsAccepted = true
                    });
                }
            }

            await unitOfWork.SaveAsync();

            return new CollectionResult<UserUnitRoleDTO>(true, true, new UserUnitRoleDTO());
        }
    }
}
