using Domain.DataTransferObjects.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.User.SignIn
{
    public class SignInDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public CaptchaDTO Captcha { get; set; }
    }
}
