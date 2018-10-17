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
    public class RecurringTransactionsController : ControllerBase
    {
        private readonly CashFlowDBContext _context;

        public RecurringTransactionsController(CashFlowDBContext context)
        {
            _context = context;
        }

        // GET: api/RecurringTransactions
        [HttpGet]
        public IEnumerable<RecurringTransaction> GetRecurringTransaction()
        {
            return _context.RecurringTransaction.Include(x => x.Schedule);
        }

        // GET: api/RecurringTransactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecurringTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recurringTransaction = await _context.RecurringTransaction
                .Include(x => x.Schedule)
                .Include(x => x.Account)
                .Include(x => x.TransactionType)
                .SingleOrDefaultAsync(x => x.RecurringTransactionId == id);

            if (recurringTransaction == null)
            {
                return NotFound();
            }

            return Ok(recurringTransaction);
        }

        // PUT: api/RecurringTransactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurringTransaction([FromRoute] int id, [FromBody] RecurringTransaction recurringTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recurringTransaction.RecurringTransactionId)
            {
                return BadRequest();
            }

            _context.Entry(recurringTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecurringTransactionExists(id))
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

        // POST: api/RecurringTransactions
        [HttpPost]
        public async Task<IActionResult> PostRecurringTransaction([FromBody] RecurringTransaction recurringTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RecurringTransaction.Add(recurringTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurringTransaction", new { id = recurringTransaction.RecurringTransactionId }, recurringTransaction);
        }

        // DELETE: api/RecurringTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurringTransaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recurringTransaction = await _context.RecurringTransaction.FindAsync(id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }

            _context.RecurringTransaction.Remove(recurringTransaction);
            await _context.SaveChangesAsync();

            return Ok(recurringTransaction);
        }

        private bool RecurringTransactionExists(int id)
        {
            return _context.RecurringTransaction.Any(e => e.RecurringTransactionId == id);
        }
    }
}