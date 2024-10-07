using Application.Features.Request.UserProfile.Commands;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Entities.User.Enum;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Helper;
using Utility.Services.Enum;

namespace Application.Features.RequestHandler.UserProfile.Commands
{
    public class UpdateProfileUserCommandRequestHandler : IRequestHandlerWrapper<UpdateProfileUserCommandRequest, UserDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProfileUserCommandRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UserDTO>> Handle(UpdateProfileUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepository.FindByExpression(w => w.ID == request.CurrentUser.AuthUserId);

            if (user is null)
                return new CollectionResult<UserDTO>(true, false,
                    UtilityHelper.AddDangerToCollectionResultMessage("Danger_User_Empty"));

            if(await unitOfWork.UserRepository.IsExists(w => w.ID != request.CurrentUser.AuthUserId && w.Email == request.User.Email))
                return new CollectionResult<UserDTO>(true, false,
                    UtilityHelper.AddDangerToCollectionResultMessage(Contract.Resources.Account.AccountResource.User_Queries_Signup_Exist_Email));

            if (await unitOfWork.UserRepository.IsExists(w => w.ID != request.CurrentUser.AuthUserId && w.Mobile == request.User.Mobile))
                return new CollectionResult<UserDTO>(true, false,
                    UtilityHelper.AddDangerToCollectionResultMessage(Contract.Resources.Account.AccountResource.User_Queries_Signup_Exist_Mobile));

            
            user.UserDetail = await unitOfWork.UserDetailRepository.FindByExpression(w => w.UserID == user.ID);

            user.FirstName = request.User.FirstName;
            user.LastName = request.User.LastName;
            user.Gender = request.User.Gender;

            user.Email = request.User.Email;
            user.Mobile = request.User.Mobile;

            if (user.UserDetail is null)
            {
                user.UserDetail = new UserDetail();
                user.UserDetail.UserID = user.ID;
                user.UserDetail.Address = request.User.UserDetail?.Address;
                user.UserDetail.Image = request.User.UserDetail?.Image;
            }
            else
            {
                user.UserDetail.Address = request.User.UserDetail?.Address;
                user.UserDetail.Image = request.User.UserDetail?.Image;
            }

            await unitOfWork.UserRepository.Update(user);
            await unitOfWork.SaveAsync();

            var UserDTO = mapper.Map<Domain.Entities.User.User, UserDTO>(user);

            UserDTO!.UserTypeModels = EnumConvertor.EnumToListModel<UserType>();
            UserDTO!.UserStatusModels = EnumConvertor.EnumToListModel<UserStatus>();
            UserDTO!.GenderModels = EnumConvertor.EnumToListModel<Gender>();

            return new CollectionResult<UserDTO>(true, true, UserDTO,
                UtilityHelper.AddSuccessToCollectionResultMessage("Success_User_Updated"));
        }
    }
}
