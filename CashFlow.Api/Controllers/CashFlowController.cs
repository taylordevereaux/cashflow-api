using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Api.Repository;
using CashFlow.Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashFlowController : ControllerBase
    {
        private readonly CashFlowDBContext _context;

        public CashFlowController(CashFlowDBContext context)
        {
            _context = context;
        }

        // GET api/values
       [HttpGet("/api/[controller]/summary")]
        public async Task<IActionResult> GetSummary()
        {
            //var repeatTransactions = await _context
            //    .RecurringTransaction
            //    .Select(x => new
            //    {
            //        Account = new
            //        {
            //            x.Account.Name,
            //            x.Account.Amount
            //        },
            //        x.Amount,
            //        x.CreatedDate,
            //        x.StartDate,
            //        TransactionType = new
            //        {
            //            x.TransactionType.TransactionTypeConstant
            //        },
            //        RepeatType = new
            //        {
            //            x.RepeatType.RepeatTypeConstant
            //        },
            //    })
            //    //.Where(x => x.RepeatTransactionId == id)
            //    .ToListAsync();

            //var month = DateTime.Now.GetLastDayAndTimeOfMonth();

            //var months = month.Repeat(RepeatType.Monthly, 12);

            return Ok();
        }

        // GET api/values
        [HttpGet("/api/[controller]/summary/{id}")]
        public async Task<IActionResult> GetTransactionSummary(int id)
        {
            //var repeatTransaction = await _context
            //    .RecurringTransaction
            //    .Include(x => x.RepeatType)
            //    .Include(x => x.TransactionType)
            //    .Where(x => x.RepeatTransactionId == id)
            //    .SingleOrDefaultAsync();

            //var transactions = RepeatTransactionManager.RepeatTransaction(repeatTransaction, 12).ToList();

            //var summary = new
            //{
            //    Sum = transactions.Sum(x => x.Amount) *
            //          (repeatTransaction.TransactionType.TransactionTypeConstant == "EXPENSE" ? -1 : 1),
            //    Date = transactions.Max(x => x.TransactionDate)
            //};

            //return Ok(new
            //{
            //    RepeatTransaction = repeatTransaction,
            //    Summary = summary,
            //    Transactions = transactions,
            //});
            return null;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //var repeatTransaction = await _context
            //    .RepeatTransaction
            //    .Select(x => new
            //    {
            //        x.RepeatTransactionId,
            //        Account = new
            //        {
            //            x.Account.Name,
            //            x.Account.AccountId
            //        },
            //        x.Amount,
            //        x.CreatedDate,
            //        x.StartDate,
            //        TransactionType = new
            //        {
            //            x.TransactionType.TransactionTypeConstant,
            //            x.TransactionType.Name
            //        },
            //        RepeatType = new
            //        {
            //            x.RepeatType.RepeatTypeConstant,
            //            x.RepeatType.Name
            //        },
            //    })
            //    .Where(x => x.RepeatTransactionId == id)
            //    .SingleOrDefaultAsync();

            return Ok();
        }
    }
}
