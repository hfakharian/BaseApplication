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
    public class DeleteUserUnitRoleCommandRequestHandler : IRequestHandlerWrapper<DeleteUserUnitRoleCommandRequest, UserUnitRoleDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteUserUnitRoleCommandRequestHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UserUnitRoleDTO>> Handle(DeleteUserUnitRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var userUnitRole = await unitOfWork.UserUnitRoleRepository.FindByExpression(w => w.UnitID == request.CurrentUser.AuthUnitId && w.UserID == request.UserID);

            if (userUnitRole is null)
                return new CollectionResult<UserUnitRoleDTO>(false, false,
                    UtilityHelper.AddErrorToCollectionResultMessage("Delete_UserUnitRole_Null"));

            await unitOfWork.UserUnitRoleRepository.Delete(userUnitRole);
            await unitOfWork.SaveAsync();

            return new CollectionResult<UserUnitRoleDTO>(true, true, new UserUnitRoleDTO());
        }
    }
}
