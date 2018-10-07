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
    public class CashFlowController : ControllerBase
    {
        private readonly FinanceDBContext _context;

        public CashFlowController(FinanceDBContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet("/api/[controller]/summary")]
        public async Task<IActionResult> GetSummary()
        {
            var repeatTransactions = await _context
                .RepeatTransaction
                .Select(x => new
                {
                    Account = new
                    {
                        x.Account.Name,
                        x.Account.Amount
                    },
                    x.Amount,
                    x.CreatedDate,
                    x.StartDate,
                    TransactionType = new
                    {
                        x.TransactionType.TransactionTypeConstant
                    },
                    RepeatType = new
                    {
                        x.RepeatType.RepeatTypeConstant
                    },
                })
                //.Where(x => x.RepeatTransactionId == id)
                .ToListAsync();

            List<DateTime> dates = new List<DateTime>();
            DateTime now = DateTime.Now;
            dates.Add(now);
            dates.Add(now.GetFirstDayOfMonth());
            dates.Add(now.GetFirstDayAndTimeOfMonth());
            dates.Add(now.GetLastDayOfMonth());
            dates.Add(now.GetLastDayAndTimeOfMonth());

            return Ok(dates);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var repeatTransaction = await _context
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
    }
}
