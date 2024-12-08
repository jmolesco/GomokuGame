using PG.API.DataModels;
using PG.API.Interfaces.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.API.Interfaces.IRepo
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        Task<List<Player>> RetrievePlayers();
        Task<Player> RetrievePlayerByName(string name);
    }
}