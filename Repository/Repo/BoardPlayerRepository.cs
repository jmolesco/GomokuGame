using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PG.API.DataModels;
using PG.API.Infrastructure.Cache;
using PG.API.Interfaces.IRepo;
using PG.API.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PG.API.Repository.Repo
{
    public class BoardPlayerRepository : GenericRepository<BoardPlayer>, IBoardPlayerRepository
    {
        private readonly ILogger<BoardPlayerRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;
        private readonly IHttpClientFactory _clientFactory;
        private readonly GomokuDBContext _gomokuDBContext;
        public BoardPlayerRepository(ILogger<BoardPlayerRepository> logger, IConfiguration configuration, 
            ICacheService cacheService, IHttpClientFactory clientFactory,
            GomokuDBContext gomokuDBContext) : base(gomokuDBContext)
        {
            _logger = logger;
            _configuration = configuration;
            _cacheService = cacheService;
            _clientFactory = clientFactory;
            _gomokuDBContext = gomokuDBContext;
        }
        public async Task<BoardPlayer> RetrieveBoardAndPlayerById(Guid id)
        {
            _logger.LogInformation("BoardPlayerRepository - RetrieveBoardGameById - Started method ");
            _logger.LogInformation("BoardPlayerRepository - RetrieveBoardGameById");
            var _result = await _gomokuDBContext.BoardPlayers
                .Include(x=>x.BoardGame)
                .Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            _logger.LogInformation("BoardPlayerRepository - RetrieveBoardGameById");
            return _result;
        }
    }
}