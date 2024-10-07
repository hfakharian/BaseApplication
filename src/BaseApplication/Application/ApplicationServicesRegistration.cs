using Application.Behaviours;
using Application.Profiles;
using Application.Security.AuthenticationRole;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddValidatorsFromAssembly(typeof(ApplicationServicesRegistration).Assembly);

            services.AddScoped<IServiceAuthenticationRole, ServiceAuthenticationRole>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly);
                cfg.AddOpenRequestPreProcessor(typeof(AuthenticateRequestPreProcessor<>), serviceLifetime: ServiceLifetime.Scoped);
                //cfg.AddOpenRequestPreProcessor(typeof(AuthenticateValidationRequestPreProcessor<>), serviceLifetime: ServiceLifetime.Scoped);
                cfg.AddOpenRequestPreProcessor(typeof(ValidationRequestPreProcessor<>), serviceLifetime: ServiceLifetime.Scoped);
            });
            return services;
        }
    }
}
