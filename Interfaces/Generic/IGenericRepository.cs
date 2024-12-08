using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.API.Interfaces.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entity);
        void Update(T entity);  
    }
}
