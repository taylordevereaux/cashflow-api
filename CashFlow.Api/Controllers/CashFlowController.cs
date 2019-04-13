using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CashFlow.Api.Extensions;
using CashFlow.Api.Models;
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
        [HttpGet("Summary")]
        public async Task<IActionResult> GetSummary([FromBody] SummaryOptions options)
        {
            var accounts = await _context
                .Accounts
                .Where(x => options.AccountId == null || options.AccountId == x.AccountId)
                .Include(x => x.RecurringTransactions)
                .ThenInclude(x => x.Schedule)
                .Include(x => x.RecurringTransactions)
                .ThenInclude(x => x.TransactionType)
                .ToListAsync();

            // Default the start date to today if not passed in.
            DateTime startDate = options.StartDate ?? DateTime.Now;
            // Define the schedule with the provided options.
            var schedule = RecurringDateBuilder.Build(new Schedule()
            {
                StartDate = startDate,
                RecurrenceType = options.Recurrence.ToString(),
                RecurrenceAmount = options.RecurrenceMultiplier,
                EndDate = DateTime.MaxValue
            });
            // Determine the amount of dates that will occure given the schedule options provided.
            var ranges = schedule
                .Until(startDate, options.RecurrenceCount);

            // The total amount of all accounts, we will increment this with each date occurence above.
            var amount = accounts.Sum(x => x.Amount);

            var results = new List<(DateTime date, decimal amount)>();

            var transactions = accounts
                .SelectMany(x => x.RecurringTransactions)
                .ToList();

            var schedules = transactions
                .Select(x => new
                {
                    x.Amount,
                    Schedule = RecurringDateBuilder.Build(x.Schedule)
                })
                .ToList();

            foreach (var s in schedules)
            {
                var temp = s.Schedule.Until(startDate, ranges[0]);
            }

            foreach (var range in ranges.OrderBy(x => x))
            {
                var rangeSum =
                    schedules.Sum(x => x.Amount * x.Schedule.Until(startDate, range).Count);
                amount += rangeSum;

                startDate = range;

                results.Add((range, amount));
            }

            return Ok(results);
        }

        // GET api/values
        //[HttpGet("/Summary/{id}")]
        //public async Task<IActionResult> GetTransactionSummary(int id)
        //{
        //    //var repeatTransaction = await _context
        //    //    .RecurringTransaction
        //    //    .Include(x => x.RepeatType)
        //    //    .Include(x => x.TransactionType)
        //    //    .Where(x => x.RepeatTransactionId == id)
        //    //    .SingleOrDefaultAsync();

        //    //var transactions = RepeatTransactionManager.RepeatTransaction(repeatTransaction, 12).ToList();

        //    //var summary = new
        //    //{
        //    //    Sum = transactions.Sum(x => x.Amount) *
        //    //          (repeatTransaction.TransactionType.TransactionTypeConstant == "EXPENSE" ? -1 : 1),
        //    //    Date = transactions.Max(x => x.TransactionDate)
        //    //};

        //    //return Ok(new
        //    //{
        //    //    RepeatTransaction = repeatTransaction,
        //    //    Summary = summary,
        //    //    Transactions = transactions,
        //    //});
        //    return null;
        //}
        // GET api/values/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    //var repeatTransaction = await _context
        //    //    .RepeatTransaction
        //    //    .Select(x => new
        //    //    {
        //    //        x.RepeatTransactionId,
        //    //        Account = new
        //    //        {
        //    //            x.Account.Name,
        //    //            x.Account.AccountId
        //    //        },
        //    //        x.Amount,
        //    //        x.CreatedDate,
        //    //        x.StartDate,
        //    //        TransactionType = new
        //    //        {
        //    //            x.TransactionType.TransactionTypeConstant,
        //    //            x.TransactionType.Name
        //    //        },
        //    //        RepeatType = new
        //    //        {
        //    //            x.RepeatType.RepeatTypeConstant,
        //    //            x.RepeatType.Name
        //    //        },
        //    //    })
        //    //    .Where(x => x.RepeatTransactionId == id)
        //    //    .SingleOrDefaultAsync();

        //    return Ok();
        //}
    }
}
