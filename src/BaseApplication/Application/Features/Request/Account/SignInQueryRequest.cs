using Application.Wrappers;
using Domain.DataTransferObjects.User.SignIn;

namespace Application.Features.Request.Account
{
    public class SignInQueryRequest : IRequestWrapper<SignInResponseDTO>
    {
        public SignInDTO User { get; set; }
    }
}
