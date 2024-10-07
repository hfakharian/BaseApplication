using Contract.Services.Captcha;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utility.Security;
using Utility.Services.Captcha;

namespace Utility
{
    public static class UtilityServicesRegistration
    {

        public static IServiceCollection ConfigureUtilityServices(this IServiceCollection services, IConfiguration configuration)
        {

            //services.Configure<AESConfig>(configuration.GetSection("AESConfig"));
            services.AddSingleton<ICipherAlgorithm, CipherAlgorithm>();

            #region Captcha
            services.AddSingleton<ICaptchaService, CaptchaService>();
            services.AddSingleton<ICaptchaCodeGenerator, CaptchaCodeGenerator>();
            services.AddSingleton<ICaptchaImageGenerator, CaptchaImageGenerator>();
            #endregion

            return services;
        }

    }
}
