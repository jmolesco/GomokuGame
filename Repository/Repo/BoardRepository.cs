using Auth0.ManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PG.API.DataModels;
using PG.API.Infrastructure.Cache;
using PG.API.Interfaces.IRepo;
using PG.API.Repository.Generic;
using Polly;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PG.API.Repository.Repo
{
    public class BoardRepository : GenericRepository<BoardGame>, IBoardRepository
    {
        private readonly ILogger<BoardRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;
        private readonly IHttpClientFactory _clientFactory;
        private readonly GomokuDBContext _gomokuDBContext;
        public BoardRepository(ILogger<BoardRepository> logger, IConfiguration configuration, ICacheService cacheService, IHttpClientFactory clientFactory,
            GomokuDBContext gomokuDBContext) : base(gomokuDBContext)
        {
            _logger = logger;
            _configuration = configuration;
            _cacheService = cacheService;
            _clientFactory = clientFactory;
            _gomokuDBContext = gomokuDBContext;
        }
        public async Task<int> RetrieveId()
        {
            _logger.LogInformation("BoardRepository - RetrieveId - Started method ");
            _logger.LogInformation("BoardRepository - RetrieveId");
            var _result = await _gomokuDBContext.BoardGames.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            int Id = 0;
            if (_result != null) { Id = _result.Id; };
            _logger.LogInformation("BoardRepository - RetrieveId");

            return Id;
        }
        public async Task<List<BoardGame>> RetrieveBoardGame()
        {
            _logger.LogInformation("BoardRepository - RetrieveBoardGame - Started method ");
            _logger.LogInformation("BoardRepository - RetrieveBoardGame");
            var _result = await _gomokuDBContext.BoardGames.Include(x=>x.BoardDesigns)
                                                            .AsNoTracking()
                                                            .AsSplitQuery()
                                                            .ToListAsync();
            _logger.LogInformation("BoardRepository - RetrieveBoardGame");
            return _result;
        }
        public async Task<BoardGame> RetrieveBoardGameById(int id)
        {
            _logger.LogInformation("BoardRepository - RetrieveBoardGameById - Started method ");
            _logger.LogInformation("BoardRepository - RetrieveBoardGameById");
            var _result = await _gomokuDBContext.BoardGames.Include(x => x.BoardDesigns).Where(x=>x.Id==id)
                                                            .AsNoTracking()
                                                            .AsSplitQuery()
                                                            .FirstOrDefaultAsync();
            _logger.LogInformation("BoardRepository - RetrieveBoardGameById");
            return _result;
        }

        public async Task<bool> ClearRecords()
        {
            _gomokuDBContext.Database.ExecuteSqlRaw("TRUNCATE TABLE BoardDesign");
            _gomokuDBContext.Database.ExecuteSqlRaw("TRUNCATE TABLE BoardPlayer");
            _gomokuDBContext.Database.ExecuteSqlRaw("TRUNCATE TABLE BoardGame");
            _gomokuDBContext.Database.ExecuteSqlRaw("TRUNCATE TABLE Player");
            return true;
        }
    }
}
