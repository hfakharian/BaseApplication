using Contract.Services.Captcha;
using Domain.DataTransferObjects.General;
using Utility.Extensions;
using Utility.Security;

namespace Utility.Services.Captcha
{
    public class CaptchaService : ICaptchaService
    {
        private readonly ICaptchaImageGenerator captchaGenerator;
        private readonly ICaptchaCodeGenerator captchaCodeGenerator;
        private readonly ICipherAlgorithm cipherAlgorithm;
        private const int MaxTimeToGuessInSecods = 5 * 60; //5Minutes

        public CaptchaService(ICaptchaImageGenerator captchaGenerator,
            ICaptchaCodeGenerator captchaCodeGenerator,
            ICipherAlgorithm cipherAlgorithm)
        {
            this.captchaGenerator = captchaGenerator;
            this.captchaCodeGenerator = captchaCodeGenerator;
            this.cipherAlgorithm = cipherAlgorithm;
        }

        public CaptchaDTO GenerateEncryptedCaptcha()
        {
            var captchaChars = captchaCodeGenerator.GenerateCode();
            var captchImage = captchaGenerator.GenerateImageAsBase64(captchaChars);
            var captchaCode = cipherAlgorithm.EncryptString($"{captchaChars.ToLowerInvariant()}:{DateTime.Now.ToUnixTimeSeconds() + MaxTimeToGuessInSecods}");
            return new CaptchaDTO(captchImage, captchaCode, MaxTimeToGuessInSecods);
        }

        public bool IsValidCaptcha(string captchaEncryptedValue, string userValue)
        {
            var dec = cipherAlgorithm.DecryptString(captchaEncryptedValue);
            var res = dec.Split(":");
            if (res.Length != 2)
            {
                return false;
            }
            //TODO: check if captcha is expired
            if (DateTime.Now.ToUnixTimeSeconds() > res[1].ToInt32())
            {
                return false;
            }

            return res[0] == userValue;
        }
    }
}
