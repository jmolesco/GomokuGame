using PG.API.DTO;
using PG.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PG.API.Interfaces.IService
{
    public interface IGomokuService
    {
       
        #region Board -  Step 1 Create the board first
        Task<BoardResponse> CreateBoard();
        Task<BoardResponse> RetrieveBoardById(int Id);
        Task<List<BoardResponse>> RetrieveBoardGame();
        #endregion

        #region Player  -  Step 2 Create user
        Task<PlayerResponse> CreatePlayer(PlayerRequest player);
        Task<PlayerResponse> RetrievePlayer(string name);
        Task<List<PlayerResponse>> RetrievePlayers();
        #endregion

        #region Board Player -   Step 3 Register the 2 users, Player 1 and Player 2 to the board
        Task<BoardPlayerResponse> RegisterBoardAndPlayer(BoardPlayerRequest request);
        Task<BoardPlayerResponse> RetrieveBoardAndPlayer(Guid id);
        #endregion

        #region PlayGame - Step 4 Play the game
        Task<BoardResponse> PlayGame(PlayGameRequest request);
        #endregion

    }
}
