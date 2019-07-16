using System.Threading.Tasks;

namespace Accounting.Api.Contracts
{
    public interface IUnitOfWork
    {
        
        IVoucherRepository Voucher { get; }
        Task SaveAsync();

    }
}