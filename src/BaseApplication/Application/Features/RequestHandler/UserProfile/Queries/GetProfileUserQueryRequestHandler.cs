using Application.Features.Request.UserProfile.Queries;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.Entities.User.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Services.Enum;

namespace Application.Features.RequestHandler.UserProfile.Queries
{
    public class GetProfileUserQueryRequestHandler : IRequestHandlerWrapper<GetProfileUserQueryRequest, UserDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetProfileUserQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CollectionResult<UserDTO>> Handle(GetProfileUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.UserRepository.FindByExpression(x => x.UserStatus == UserStatus.Active && x.ID == request.CurrentUser.AuthUserId, includeProperties: "UserDetail");

            if (user.UserDetail is null)
                user.UserDetail = new Domain.Entities.User.UserDetail();

            var UserDTO = mapper.Map<Domain.Entities.User.User, UserDTO>(user ?? new Domain.Entities.User.User());

            UserDTO!.UserTypeModels = EnumConvertor.EnumToListModel<UserType>();
            UserDTO!.UserStatusModels = EnumConvertor.EnumToListModel<UserStatus>();
            UserDTO!.GenderModels = EnumConvertor.EnumToListModel<Gender>();

            return new CollectionResult<UserDTO>(true, true, UserDTO);
        }
    }
}
