using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting.Api.Entities
{
    public class Voucher
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        // public List<VoucherDetail> Detail { get; set; }
        
    }

    public class VoucherDetail
    {
        public string AccountId { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }




    }
}