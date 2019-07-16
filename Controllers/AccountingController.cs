using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Api.Contracts;
using Accounting.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {

        private readonly IUnitOfWork uow;

        public AccountingController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVouchers()
        {
            return Ok(await uow.Voucher.QueryAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVoucher(int id)
        {
            var voucher = await uow.Voucher.GetAsync(id);
            if (voucher == null) return NotFound();

            return Ok(voucher);
        }

        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(Voucher item)
        {

            await uow.Voucher.AddAsync(item);
            await uow.SaveAsync();
            
            return CreatedAtAction(nameof(GetVoucher), new Voucher{Id = item.Id}, item);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucher(int id, Voucher item)
        {

            if (id != item.Id) return BadRequest();

            var voucher = await uow.Voucher.GetAsync(id);
            if (voucher == null) return NotFound();

            await uow.Voucher.UpdateAsync(voucher, item);
            await uow.SaveAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(int id)
        {
            var voucher = await uow.Voucher.GetAsync(id);

            if (voucher == null) return NotFound();

            await uow.Voucher.DeleteAsync(voucher);
            await uow.SaveAsync();

            return NoContent();

        }

    }
}
