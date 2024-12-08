using PG.API.DataModels;
using PG.API.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.API.Interfaces.IRepo
{
    public interface IBoardPlayerRepository : IGenericRepository<BoardPlayer>
    {
        Task<BoardPlayer> RetrieveBoardAndPlayerById(Guid id);
    }
}