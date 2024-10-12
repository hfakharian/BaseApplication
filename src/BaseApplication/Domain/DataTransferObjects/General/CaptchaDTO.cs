using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.General
{
    public record CaptchaDTO
    {
        public CaptchaDTO()
        {
        }
        public CaptchaDTO(string captchaImage, string captchaCode,int captchaTime)
        {
            CaptchaImage = captchaImage;
            CaptchaCode = captchaCode;
            CaptchaTime = captchaTime;
        }
        public string CaptchaImage { get; set; }
        public string CaptchaCode { get; set; }
        public int CaptchaTime { get; set; }
        public string Captcha { get; set; } = string.Empty;
    }
}
