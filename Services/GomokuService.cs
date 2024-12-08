using AutoMapper;
using Microsoft.Extensions.Configuration;
using PG.API.DataModels;
using PG.API.DTO;
using PG.API.Interfaces.IService;
using PG.API.Interfaces.IUnitofwork;
using PG.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PG.API.Services
{
    public class GomokuService : BaseService<GomokuService>, IGomokuService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IGomokuUnitofwork _unitofwork;
        public GomokuService(IBaseDependenciesService<GomokuService> dependencies,
           IConfiguration configuration,
           IGomokuUnitofwork unitofwork,
           IMapper mapper
        ) : base(dependencies)
        {
            _configuration = configuration;
            _unitofwork = unitofwork;
            _mapper = mapper;   
        }

        #region  Board -  Step 1 Create the board first
        public async Task<BoardResponse> CreateBoard()
        {
            var boardInfo = await _unitofwork.boardRepository.RetrieveId();
            var Id = boardInfo + 1;
            List<List<char>> _board = new List<List<char>>();
            Dictionary<int, List<char>>  _board1 = new Dictionary<int, List<char>>();
            List<char> columns = new List<char>();
            List< BoardDesignRequest > bDesignGame = new List<BoardDesignRequest>();
            for (int i = 0; i < 15; i++)
            {
                _board.Add(new List<char>());
                for (int j = 0; j < 15; j++)
                {
                    _board[i].Add('.');
                    columns.Add('.');
                    BoardDesignRequest model = new BoardDesignRequest() {
                        BoardId = Id,
                        Row = i.ToString(),
                        Column = j.ToString(),
                        Id= Guid.NewGuid(),
                    };
                    bDesignGame.Add(model);

                }
                _board1.Add(i, columns);
            }
            var boardgame = _mapper.Map<List<BoardDesign>>(bDesignGame);
            BoardGame bGame = new BoardGame()
            {
                Id = Id,
                BoardDesigns = boardgame,
                BoardName = "Board "+ Id
            };
         

            await _unitofwork.boardRepository.Add(bGame);
            _unitofwork.Save();

            return await RetrieveBoardById(Id);
        }
        public async Task<BoardResponse>  RetrieveBoardById(int Id)
        {
            var boards = await _unitofwork.boardRepository.RetrieveBoardGameById(Id);
            var mappedBoard = _mapper.Map<BoardResponse>(boards);
            return mappedBoard;

        }

        public async Task<List<BoardResponse>> RetrieveBoardGame()
        {
            var boards = await _unitofwork.boardRepository.RetrieveBoardGame();
            var mappedBoard = _mapper.Map<List<BoardResponse>>(boards);
            return mappedBoard;

        }
        #endregion

        #region Player  -  Step 2 Create user

        public async Task<PlayerResponse> CreatePlayer(PlayerRequest player)
        {
            var mappedPlayer = _mapper.Map<Player>(player);
            await  _unitofwork.playerRepository.Add(mappedPlayer);
            _unitofwork.Save();
            return await RetrievePlayer(mappedPlayer.Name);
        }
        public async Task<PlayerResponse> RetrievePlayer(string name)
        {
            var player = await _unitofwork.playerRepository.RetrievePlayerByName(name);
            var mappedPlayer = _mapper.Map<PlayerResponse>(player);
            return mappedPlayer;
        }
        public async Task<List<PlayerResponse>> RetrievePlayers()
        {
            var player = await _unitofwork.playerRepository.RetrievePlayers();
            var mappedPlayer = _mapper.Map<List<PlayerResponse>>(player);
            return mappedPlayer;
        }
        #endregion

        #region Board And Player - Step 3  Register the Player to the board
        public async Task<BoardPlayerResponse> RegisterBoardAndPlayer(BoardPlayerRequest request)
        {
            var mappedBoardPlayer = _mapper.Map<BoardPlayer>(request);
            await _unitofwork.boardPlayerRepository.Add(mappedBoardPlayer);
            _unitofwork.Save();
            return await RetrieveBoardAndPlayer(mappedBoardPlayer.Id);
        }
        public async Task<BoardPlayerResponse> RetrieveBoardAndPlayer(Guid id)
        {
            var player = await _unitofwork.boardPlayerRepository.RetrieveBoardAndPlayerById(id);
            var mappedPlayer = _mapper.Map<BoardPlayerResponse>(player);
            return mappedPlayer;
        }
        #endregion


        #region PlayGame - Step 4 Play the game
        public async Task<BoardResponse> PlayGame(PlayGameRequest request)
        {
            var board = await _unitofwork.boardRepository.RetrieveBoardGameById(request.BoardId);
            var player = await RetrievePlayer(request.Name);
            if (board == null)
                return new BoardResponse { BoardMessage = "Board not found" };

            if (player == null)
                return new BoardResponse { BoardMessage = "Player not found" };


            var boardDesign = board.BoardDesigns.Where(x => x.Row == request.Row.ToString() && x.Column == request.Column.ToString()).FirstOrDefault();
            if (boardDesign != null &&boardDesign.ColumnValue==null)
            {
               
                var mappedBoardDesign = _mapper.Map<BoardDesign>(boardDesign);
                mappedBoardDesign.ColumnValue = player.NameIcon;
                board.BoardDesigns = new List<BoardDesign>() { mappedBoardDesign };
                _unitofwork.boardRepository.Update(board);
                _unitofwork.Save();

                //bool isWinnerFound = PlayGomoku(board.BoardDesigns, player.NameIcon);
                //if (!isWinnerFound)
                //{
                //    return new BoardResponse { BoardMessage = "The game is a draw!" };
                //}
            }
            else
            {
                //should try again
                return new BoardResponse { BoardMessage = "Please enter again the row and column. Input might have taken or not exists" };
            }

            return await RetrieveBoardById(request.BoardId);

        }

        //public bool PlayGomoku(List<BoardDesign> board, string nameIcon)
        //{
        //    bool isWinnerFound = false;
        //    // Check for horizontal wins.
        //    //for (int i = 0; i < 15; i++)
        //    //{
        //    //    for (int j = 0; j < 14; j++)
        //    //    {
        //    //        //if (_board[i][j] == player &&
        //    //        //    _board[i][j + 1] == player &&
        //    //        //    _board[i][j + 2] == player &&
        //    //        //    _board[i][j + 3] == player &&
        //    //        //    _board[i][j + 4] == player)
        //    //        //{
        //    //        //    return true;
        //    //        //}
        //    //        if(board)
        //    //    }
        //    //}
        //    for()
        //    return isWinnerFound;
        //}


        #endregion


    }
}
