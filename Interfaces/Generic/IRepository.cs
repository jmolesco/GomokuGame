using System;

namespace PG.API.Interfaces.Generic
{
    public interface IRepository<T> : IDisposable where T : class
    {
    }
}
