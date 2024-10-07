using Application.Features.Request.UserUnitRole.Commands;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RequestHandler.UserUnitRole.Commands
{
    public class CreateUserUnitRoleCommandRequestHandler : IRequestHandlerWrapper<CreateUserUnitRoleCommandRequest, UserUnitRoleDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateUserUnitRoleCommandRequestHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UserUnitRoleDTO>> Handle(CreateUserUnitRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.UserUnitRoleRepository.Create(new Domain.Entities.User.UserUnitRole
            {
                UnitID = request.CurrentUser.AuthUnitId,
                UserID = request.UserUnitRole.User.ID ?? 0,
                RoleID = request.UserUnitRole.Role.ID ?? 0,
                IsAccepted = true
            });
            await unitOfWork.SaveAsync();

            return new CollectionResult<UserUnitRoleDTO>(true, true, new UserUnitRoleDTO());
        }
    }
}
