using Utility.Extensions;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Utility.Helper;
using Domain.DataTransferObjects.User.SignIn;
using Domain.DataTransferObjects.User;
using Domain.Options;
using Application.Security;
using Application.Features.Request.Account;

namespace Application.Features.RequestHandler.Account
{
    public class SignInQueryRequestHandler : IRequestHandlerWrapper<SignInQueryRequest, SignInResponseDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly JwtSettings jwtSettings;

        public SignInQueryRequestHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            JwtSettings jwtSettings)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.jwtSettings = jwtSettings;
        }

        public async Task<CollectionResult<SignInResponseDTO>> Handle(SignInQueryRequest request, CancellationToken cancellationToken)
        {
            string encryptedPassword = UtilityHelper.PasswordEncrypt(request.User.Password);
            var user = await unitOfWork.UserRepository.FindByExpression(x => x.Username == request.User.Username);

            if (user is null || user.Password != encryptedPassword)
                return new CollectionResult<SignInResponseDTO>(false, false,
                    UtilityHelper.AddDangerToCollectionResultMessage(Contract.Resources.Account.AccountResource.User_Queries_SignIn_Invalid_Username_Password));


            user.UserDetail = await unitOfWork.UserDetailRepository.FindByExpression(x => x.UserID == user.ID, string.Empty);


            var token = JwtProvider.JwtGenerator(user, jwtSettings);


            var currentDate = DateTime.Now;
            var expiredDate = currentDate.AddMinutes(jwtSettings.ExpiryInMinutes.TotalMinutes);

            var responseDTO = new SignInResponseDTO
            {
                Token = token,
                TokenCreate = currentDate,
                TokenCreateUnix = currentDate.ToUnixTimeSeconds(),
                TokenExpire = expiredDate,
                TokenExpireUnix = expiredDate.ToUnixTimeSeconds(),
                User = mapper.Map<Domain.Entities.User.User, UserDTO>(user)
            };

            return new CollectionResult<SignInResponseDTO>(false, true, responseDTO);
        }
    }
}
