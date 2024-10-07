using Application.Features.Request.UserProfile.Commands;
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

namespace Application.Features.RequestHandler.UserProfile.Commands
{
    public class UpdateProfileUserPasswordCommandRequestHandler : IRequestHandlerWrapper<UpdateProfileUserPasswordCommandRequest, UserDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProfileUserPasswordCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UserDTO>> Handle(UpdateProfileUserPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            string encryptedPassword = UtilityHelper.PasswordEncrypt(request.UserPassword.CurrentPassword);

            var user = await unitOfWork.UserRepository.FindByExpression(w => w.ID == request.CurrentUser.AuthUserId);

            if (user is null || user?.Password != encryptedPassword)
                return new CollectionResult<UserDTO>(true, false,
                    UtilityHelper.AddDangerToCollectionResultMessage("Danger_User_Empty"));

            user.Password = UtilityHelper.PasswordEncrypt(request.UserPassword.NewPassword);
            user.DateChangePassword = DateTime.UtcNow;

            await unitOfWork.UserRepository.Update(user);
            await unitOfWork.SaveAsync();

            var UserDTO = mapper.Map<Domain.Entities.User.User, UserDTO>(user);

            return new CollectionResult<UserDTO>(true, true, UserDTO);
        }
    }
}
