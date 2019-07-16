using System;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Contracts
{

    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        
        Task<IQueryable<TEntity>> QueryAsync();
        Task<TEntity> GetAsync(params object[] keyValues);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity oldEntity, TEntity newEntity);
        Task DeleteAsync(TEntity entity);

    }

}