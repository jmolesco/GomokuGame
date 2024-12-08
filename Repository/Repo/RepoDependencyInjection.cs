using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PG.API.Interfaces.IRepo;
using PG.API.Interfaces.IUnitofwork;
using PG.API.Repository.Unitofwork;

namespace PG.API.Repository.Repo
{
    public static class RepoDependencyInjection
    {
        public static IServiceCollection AddRepoDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IBoardRepository, BoardRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IBoardPlayerRepository, BoardPlayerRepository>();
            return services;
        }
    }
}
