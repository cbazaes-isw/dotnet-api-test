using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Contracts;

namespace Accounting.Api.Repositories
{

    public abstract class CommonRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly Db _context;
        public CommonRepository(Db context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity oldEntity, TEntity newEntity)
        {
            await Task.Run(() => {

                var properties = typeof(TEntity).GetProperties();
                foreach (var p in properties)
                {
                    var value = p.GetValue(newEntity);
                    p.SetValue(oldEntity, value);
                }

                _context.Set<TEntity>().Update(oldEntity);

            });
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
        }

        public Task<TEntity> GetAsync(params object[] keyValues)
        {
            return _context.Set<TEntity>().FindAsync(keyValues);
        }

        public async Task<IQueryable<TEntity>> QueryAsync()
        {
            return await Task.Run(() => _context.Set<TEntity>().AsQueryable());
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CommonManager()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}