using Microsoft.Extensions.DependencyInjection;

namespace PG.API.Infrastructure.ApplicationServices
{
    public static class ApplicationServicesStartup
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}