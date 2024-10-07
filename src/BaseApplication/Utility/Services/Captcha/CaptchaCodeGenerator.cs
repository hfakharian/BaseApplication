namespace Utility.Services.Captcha
{
    public class CaptchaCodeGenerator : ICaptchaCodeGenerator
    {
        private const int CaptchaLength = 5;
        public string GenerateCode()
        {
            Random random = new Random();
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const string chars = "1";
            //const string chars = "23456789";
            return new string(Enumerable.Repeat(chars, CaptchaLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
