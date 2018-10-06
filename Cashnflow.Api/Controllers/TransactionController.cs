using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashnflow.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cashnflow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private FinanceDBContext _financeDBContext;

        public TransactionsController(FinanceDBContext financeDBContext)
        {
            _financeDBContext = financeDBContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var repeatTransactions = await _financeDBContext
                .RepeatTransaction
                .Select(x => new
                {
                    x.RepeatTransactionId,
                    Account = new
                    {
                        x.Account.Name,
                        x.Account.AccountId
                    },
                    x.Amount,
                    x.CreatedDate,
                    x.StartDate,
                    TransactionType = new
                    {
                        x.TransactionType.TransactionTypeConstant,
                        x.TransactionType.Name
                    },
                    RepeatType = new
                    {
                        x.RepeatType.RepeatTypeConstant,
                        x.RepeatType.Name
                    },
                })
                //.Where(x => x.RepeatTransactionId == id)
                .ToListAsync();

            return Ok(repeatTransactions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var repeatTransaction = await _financeDBContext
                .RepeatTransaction
                .Select(x => new
                {
                    x.RepeatTransactionId,
                    Account = new
                    {
                        x.Account.Name,
                        x.Account.AccountId
                    },
                    x.Amount,
                    x.CreatedDate,
                    x.StartDate,
                    TransactionType = new
                    {
                        x.TransactionType.TransactionTypeConstant,
                        x.TransactionType.Name
                    },
                    RepeatType = new
                    {
                        x.RepeatType.RepeatTypeConstant,
                        x.RepeatType.Name
                    },
                })
                .Where(x => x.RepeatTransactionId == id)
                .SingleOrDefaultAsync();

            return Ok(repeatTransaction);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return $"Posted: {value}";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return $"Put: {value} for id {id}";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Deleted transaction: {id}";
        }
    }
}
