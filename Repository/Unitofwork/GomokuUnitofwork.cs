using System.Threading.Tasks;
using System;
using PG.API.Interfaces.IRepo;
using PG.API.DataModels;
using PG.API.Interfaces.IUnitofwork;
using PG.API.Repository.Repo;

namespace PG.API.Repository.Unitofwork
{
    public class GomokuUnitofwork : IGomokuUnitofwork
    {
        public IBoardRepository boardRepository { get; }
        public IPlayerRepository playerRepository { get; }
        public IBoardPlayerRepository boardPlayerRepository { get; }
        private readonly GomokuDBContext _gomokuDBContext;
        public GomokuUnitofwork(GomokuDBContext gomokuDBContext,
            IBoardRepository _boardRepository,
            IPlayerRepository _playerRepository,
            IBoardPlayerRepository _boardPlayerRepository
                   )
        {
            _gomokuDBContext = gomokuDBContext;
            boardRepository = _boardRepository;
            playerRepository = _playerRepository;
            boardPlayerRepository = _boardPlayerRepository;
        }
        public int Save()
        {
            return _gomokuDBContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _gomokuDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _gomokuDBContext.Dispose();
            }
        }
    }
}