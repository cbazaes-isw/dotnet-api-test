using Accounting.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Repositories
{

    public class Db : DbContext
    {

        public Db(DbContextOptions<Db> options) : base(options)
        {
        }

        public DbSet<Voucher> Vouchers { get; set; }

    }

}