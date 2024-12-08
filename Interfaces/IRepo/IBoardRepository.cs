using Auth0.ManagementApi.Models;
using PG.API.DataModels;
using PG.API.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.API.Interfaces.IRepo
{
    public interface IBoardRepository : IGenericRepository<BoardGame>
    {
        Task<List<BoardGame>> RetrieveBoardGame();
        Task<int> RetrieveId();
        Task<BoardGame> RetrieveBoardGameById(int id);
        Task<bool> ClearRecords();

    }
}
