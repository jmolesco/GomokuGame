using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PG.API.DTO;
using PG.API.Extentions;
using PG.API.Interfaces.IService;
using System;
using System.Threading.Tasks;

namespace PG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GomukoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GomukoController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IGomokuService _service; 
        public GomukoController(ILogger<GomukoController> logger, IConfiguration configuration, IMapper mapper,
            IGomokuService service
            )
        {
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
            _service = service;
           
        }


        #region  Board -  Step 1 Create the board first

        [HttpPost("board/create")]
        public async Task<IActionResult> CreateBoard()
        {
            var result = await _service.CreateBoard();
            return result.Pipe(res => Ok(res));
        }
        [HttpGet("board/search/{Id}")]
        public async Task<IActionResult> RetrieveBoardById([FromRoute] int Id)
        {
            var result = await _service.RetrieveBoardById(Id);
            return result.Pipe(res => Ok(res));
        }
        [HttpGet("board/list")]
        public async Task<IActionResult> RetrieveBoardGame()
        {
            var result = await _service.RetrieveBoardGame();
            return result.Pipe(res => Ok(res));
        }

        #endregion

        #region Player  -  Step 2 Create user
        [HttpPost("player/create")]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerRequest player)
        {
            var result = await _service.CreatePlayer(player);
            return result.Pipe(res => Ok(res));
        }
        [HttpGet("player/search/{name}")]
        public async Task<IActionResult> RetrievePlayerByName([FromRoute] string name)
        {
            var result = await _service.RetrievePlayer(name);
            return result.Pipe(res => Ok(res));
        }
        [HttpGet("player/list")]
        public async Task<IActionResult> RetrievePlayers()
        {
            var result = await _service.RetrievePlayers();
            return result.Pipe(res => Ok(res));
        }
        #endregion

        #region Board And Player - Step 3  Register the Player to the board
        [HttpPost("boardAndPlayer/register")]
        public async Task<IActionResult> RegisterBoardAndPlayers([FromBody] BoardPlayerRequest req)
        {
            var result = await _service.RegisterBoardAndPlayer(req);
            return result.Pipe(res => Ok(res));
        }
        [HttpGet("boardAndPlayer/search/{Id}")]
        public async Task<IActionResult> RetrieveBoardAndPlayers([FromRoute] Guid Id)
        {
            var result = await _service.RetrieveBoardAndPlayer(Id);
            return result.Pipe(res => Ok(res));
        }
        #endregion

        #region Step 4 - Play the Game
        [HttpPut("playgame")]
        public async Task<IActionResult> RegisterBoardAndPlayers([FromBody] PlayGameRequest req)
        {
            var result = await _service.PlayGame(req);
            return result.Pipe(res => Ok(res));
        }

        #endregion
    }
}
