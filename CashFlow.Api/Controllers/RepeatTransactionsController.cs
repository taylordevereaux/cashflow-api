using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashFlow.Api.Repository;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepeatTransactionsController : ControllerBase
    {
        private readonly FinanceDBContext _context;

        public RepeatTransactionsController(FinanceDBContext context)
        {
            _context = context;
        }

        // GET: api/RepeatTransactions
        [HttpGet]
        public IEnumerable<RepeatTransaction> GetRepeatTransaction()
        {
            return _context.RepeatTransaction;
        }

        // GET: api/RepeatTransactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepeatTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var repeatTransaction = await _context.RepeatTransaction.FindAsync(id);

            if (repeatTransaction == null)
            {
                return NotFound();
            }

            return Ok(repeatTransaction);
        }

        // PUT: api/RepeatTransactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepeatTransaction([FromRoute] int id, [FromBody] RepeatTransaction repeatTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repeatTransaction.RepeatTransactionId)
            {
                return BadRequest();
            }

            _context.Entry(repeatTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepeatTransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RepeatTransactions
        [HttpPost]
        public async Task<IActionResult> PostRepeatTransaction([FromBody] RepeatTransaction repeatTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RepeatTransaction.Add(repeatTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepeatTransaction", new { id = repeatTransaction.RepeatTransactionId }, repeatTransaction);
        }

        // DELETE: api/RepeatTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepeatTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var repeatTransaction = await _context.RepeatTransaction.FindAsync(id);
            if (repeatTransaction == null)
            {
                return NotFound();
            }

            _context.RepeatTransaction.Remove(repeatTransaction);
            await _context.SaveChangesAsync();

            return Ok(repeatTransaction);
        }

        private bool RepeatTransactionExists(int id)
        {
            return _context.RepeatTransaction.Any(e => e.RepeatTransactionId == id);
        }
    }
}