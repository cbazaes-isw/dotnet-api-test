using System.Threading.Tasks;
using Accounting.Api.Contracts;

namespace Accounting.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private Db _context;
        public UnitOfWork(Db context)
        {
            _context = context;
        }
        
        private IVoucherRepository _voucher;
        public IVoucherRepository Voucher
        {
            get
            {
                if(_voucher == null) _voucher = new VoucherRepository(_context);
                return _voucher;
            }
        }

        public async Task SaveAsync()
        {
            await Task.Run(() => _context.SaveChangesAsync());
        }
    }
}