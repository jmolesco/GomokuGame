using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace PG.API.Interfaces.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int Commit();
        Task CompleteAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}
