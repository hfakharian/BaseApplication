using Application.Features.Request.Account;
using Application.Security;
using Application.Wrappers;
using AutoMapper;
using Contract.Repositories;
using Domain.DataTransferObjects.Collection;
using Domain.DataTransferObjects.User;
using Domain.DataTransferObjects.User.SignIn;
using Domain.Entities.User;
using Domain.Options;
using Utility.Extensions;
using Utility.Helper;

namespace Application.Features.RequestHandler.Account
{
    public class SignUpQueryRequestHandler : IRequestHandlerWrapper<SignUpQueryRequest, SignInResponseDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly JwtSettings jwtSettings;

        public SignUpQueryRequestHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            JwtSettings jwtSettings)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.jwtSettings = jwtSettings;
        }

        public async Task<CollectionResult<SignInResponseDTO>> Handle(SignUpQueryRequest request, CancellationToken cancellationToken)
        {
            bool isExist = await unitOfWork.UserRepository.IsExists(w => w.Username == request.User.Username);
            if (isExist)
                return new CollectionResult<SignInResponseDTO>(false, false,
                   UtilityHelper.AddDangerToCollectionResultMessage(Contract.Resources.Account.AccountResource.User_Queries_Signup_Exist_Username));

            isExist = await unitOfWork.UserRepository.IsExists(w => w.Email == request.User.Email);
            if (isExist)
                return new CollectionResult<SignInResponseDTO>(false, false,
                   UtilityHelper.AddDangerToCollectionResultMessage(Contract.Resources.Account.AccountResource.User_Queries_Signup_Exist_Email));

            isExist = await unitOfWork.UserRepository.IsExists(w => w.Mobile == request.User.Mobile);
            if (isExist)
                return new CollectionResult<SignInResponseDTO>(false, false,
                   UtilityHelper.AddDangerToCollectionResultMessage(Contract.Resources.Account.AccountResource.User_Queries_Signup_Exist_Mobile));


            var user = new Domain.Entities.User.User
            {
                UserType = Domain.Entities.User.Enum.UserType.System,
                UserStatus = Domain.Entities.User.Enum.UserStatus.Active,
                Gender = request.User.Gender,
                FirstName = request.User.FirstName,
                LastName = request.User.LastName,
                Email = request.User.Email,
                Mobile = request.User.Mobile,
                NationalCode = request.User.NationalCode,
                Username = request.User.Username!,
                Password = UtilityHelper.PasswordEncrypt(request.User.Password!),
            };

            await unitOfWork.UserRepository.Create(user);
            await unitOfWork.SaveAsync();

            UserDetail userDetail = new UserDetail
            {
                UserID = user.ID,
            };

            await unitOfWork.UserDetailRepository.Create(userDetail);
            await unitOfWork.SaveAsync();

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
