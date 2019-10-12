using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessOneMonitor.Data.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(long id);
        Task Create(TEntity entity);
        Task Create(IEnumerable<TEntity> entity);
        Task Update(long id, TEntity entity);
        Task Delete(long id);
    }
}
