using System.Threading.Tasks;
using System;
using PG.API.Interfaces.IRepo;

namespace PG.API.Interfaces.IUnitofwork
{
    public interface IGomokuUnitofwork : IDisposable
    {
        IBoardRepository boardRepository { get; }
        IPlayerRepository playerRepository { get; }
        IBoardPlayerRepository boardPlayerRepository { get; }
        int Save();
        Task<int> SaveAsync();
    }
}