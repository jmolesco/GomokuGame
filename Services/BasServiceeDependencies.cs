﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PG.API.Services
{
    public interface IBaseDependenciesService<T>
    {
        IMapper Mapper { get; }
        ILogger<T> Logger { get; }
        IConfiguration Configuration { get; }
    }
}

namespace PG.API.Services.Internal
{
    public class BasServiceeDependencies<T> : IBaseDependenciesService<T>
    {
        public BasServiceeDependencies(ILogger<T> logger, IConfiguration configuration,
            IMapper mapper)
        {
            Mapper = mapper;
            Logger = logger;
            Configuration = configuration;
        }

        public IMapper Mapper { get; private set; }
        public ILogger<T> Logger { get; private set; }
        public IConfiguration Configuration { get; }
    }
}
