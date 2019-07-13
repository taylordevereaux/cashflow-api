using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashFlow.Api.Repository;
using CashFlow.Api.Repository.Models;
using CashFlow.Api.Business;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecurringTransactionsController : ControllerBase
    {
        private readonly RecurringTransactionsService _service;

        public RecurringTransactionsController(RecurringTransactionsService service)
        {
            _service = service;
        }

        // GET: api/RecurringTransactions
        [HttpGet]
        public async Task<IEnumerable<RecurringTransaction>> GetRecurringTransactions()
        {
            return await _service.GetRecurringTransactions();
        }

        // GET: api/Account/{id}/RecurringTransactions
        [HttpGet("api/Account/{id}/RecurringTransactions")]
        public async Task<IEnumerable<RecurringTransaction>> GetRecurringTransactions([FromRoute] Guid id)
        {
            return await _service.GetRecurringTransactions(id);
        }

        // GET: api/RecurringTransactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecurringTransaction([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recurringTransaction = await _service.GetRecurringTransaction(id);

            if (recurringTransaction == null)
            {
                return NotFound();
            }

            return Ok(recurringTransaction);
        }

        // PUT: api/RecurringTransactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurringTransaction([FromRoute] Guid id, [FromBody] RecurringTransaction recurringTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recurringTransaction.RecurringTransactionId)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateRecurringTransaction(recurringTransaction);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.RecurringTransactionExists(id))
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

            await _service.CreateRecurringTransaction(recurringTransaction);

            return CreatedAtAction("GetRecurringTransaction", new { id = recurringTransaction.RecurringTransactionId }, recurringTransaction);
        }

        // DELETE: api/RecurringTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecurringTransaction([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recurringTransaction = await _service.GetRecurringTransaction(id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }

            await _service.DeleteRecurringTransaction(id);

            return Ok(recurringTransaction);
        }
    }
}