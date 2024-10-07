namespace Contract.Services.Captcha
{
    public interface ICaptchaImageGenerator
    {
        byte[] GenerateImageAsByteArray(string captchaCode, int imageQuality = 80);
        string GenerateImageAsBase64(string captchaCode, int imageQuality = 80);
        Stream GenerateImageAsStream(string captchaCode,int imageQuality = 80);
    }
}
