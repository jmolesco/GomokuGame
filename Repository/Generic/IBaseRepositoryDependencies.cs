using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PG.API.Repository.Generic
{
    public interface IBaseRepositoryDependencies<T>
    {
        IMapper Mapper { get; }
        ILogger<T> Logger { get; }
        IConfiguration Configuration { get; }        
    }
}
