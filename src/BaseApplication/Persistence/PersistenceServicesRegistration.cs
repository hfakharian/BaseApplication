using Contract.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EntityDBContext>(option =>
                option.UseNpgsql(configuration.GetConnectionString("ConnectionDBPostgre")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
