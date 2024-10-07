using Application.Wrappers;
using Domain.DataTransferObjects.User;
using Domain.DataTransferObjects.User.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Request.Account
{
    public class SignUpQueryRequest : IRequestWrapper<SignInResponseDTO>
    {
        public UserDTO User { get; set; }
    }
}
