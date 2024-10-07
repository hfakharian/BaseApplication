using Domain.DataTransferObjects.General;

namespace Contract.Services.Captcha
{
    public interface ICaptchaService
    {
        CaptchaDTO GenerateEncryptedCaptcha();
        bool IsValidCaptcha(string captchaEncryptedValue, string userValue);
    }
}
