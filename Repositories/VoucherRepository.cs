using Accounting.Api.Contracts;
using Accounting.Api.Entities;

namespace Accounting.Api.Repositories
{
    public class VoucherRepository : CommonRepository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(Db context) : base(context)
        {
        }
    }
}