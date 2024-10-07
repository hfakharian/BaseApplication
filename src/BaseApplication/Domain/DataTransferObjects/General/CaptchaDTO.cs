using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.General
{
    public record CaptchaDTO
    {
        public CaptchaDTO(string captchaImage, string captchaCode,int captchaTime)
        {
            CaptchaImage = captchaImage;
            CaptchaCode = captchaCode;
            CaptchaTime = captchaTime;
        }
        public string CaptchaImage { get; }
        public string CaptchaCode { get; }
        public int CaptchaTime { get; }
        public string Captcha { get; set; } = string.Empty;
    }
}
