using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PG.API.DataModels;
using PG.API.Infrastructure.Cache;
using PG.API.Interfaces.IRepo;
using PG.API.Repository.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PG.API.Repository.Repo
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        private readonly ILogger<PlayerRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;
        private readonly IHttpClientFactory _clientFactory;
        private readonly GomokuDBContext _gomokuDBContext;
        public PlayerRepository(ILogger<PlayerRepository> logger, IConfiguration configuration, ICacheService cacheService, IHttpClientFactory clientFactory,
            GomokuDBContext gomokuDBContext) : base(gomokuDBContext)
        {
            _logger = logger;
            _configuration = configuration;
            _cacheService = cacheService;
            _clientFactory = clientFactory;
            _gomokuDBContext = gomokuDBContext;
        }
        public async Task<List<Player>> RetrievePlayers()
        {
            _logger.LogInformation("PlayerRepository - RetrievePlayers - Started method ");
            _logger.LogInformation("PlayerRepository - RetrievePlayers");
            var _result = await _gomokuDBContext.Players.AsNoTracking()
                                                            .ToListAsync();
            _logger.LogInformation("PlayerRepository - RetrievePlayers");
            return _result;
        }
        public async  Task<Player> RetrievePlayerByName(string name)
        {
            _logger.LogInformation("PlayerRepository - RetrievePlayerByName - Started method ");
            _logger.LogInformation("PlayerRepository - RetrievePlayerByName");
            var _result = await _gomokuDBContext.Players.Where(x=>x.Name.ToLower().Equals(name.ToLower())).AsNoTracking()
                                                            .FirstOrDefaultAsync();
            _logger.LogInformation("PlayerRepository - RetrievePlayerByName");
            return _result;
        }
    }
}