using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PG.API.Infrastructure.AutoMapperProfiles
{
    public static class CacheStartup
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
