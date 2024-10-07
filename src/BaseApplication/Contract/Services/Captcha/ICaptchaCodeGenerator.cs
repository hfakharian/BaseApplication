using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Services.Captcha
{
    public interface ICaptchaCodeGenerator
    {
        string GenerateCode();
    }
}
