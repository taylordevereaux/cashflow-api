using CashFlow.Api.Repository;
using CashFlow.Api.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Api.Business
{
    public class RecurringTransactionsService
    {
        private readonly CashFlowDbContext _context;

        public RecurringTransactionsService(CashFlowDbContext context)
        {
            _context = context;
        }

        public async Task<RecurringTransaction> GetRecurringTransaction(Guid id)
        {
            return await _context.RecurringTransactions
                .Include(x => x.Schedule)
                .Include(x => x.Account)
                .Include(x => x.TransactionType)
                .SingleOrDefaultAsync(x => x.RecurringTransactionId == id);
        }

        public async Task<IEnumerable<RecurringTransaction>> GetRecurringTransactions()
        {
            return await _context
                .RecurringTransactions
                .Include(x => x.TransactionType)
                .ToListAsync();
        }
        public async Task<IEnumerable<RecurringTransaction>> GetRecurringTransactions(Guid accountId)
        {
            return await _context
                .RecurringTransactions
                .Where(x => x.AccountId == accountId)
                .ToListAsync();
        }

        public async Task<Guid> CreateRecurringTransaction(RecurringTransaction recurringTransaction)
        {
            // Defaulting Initial Values.
            recurringTransaction.CreatedDate = DateTime.Now;

            var result = _context.RecurringTransactions.Add(recurringTransaction);

            await _context.SaveChangesAsync();

            return result.Entity.RecurringTransactionId;
        }

        public async Task UpdateRecurringTransaction(RecurringTransaction recurringTransaction)
        {

            _context.Entry(recurringTransaction).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Guid> DeleteRecurringTransaction(Guid id)
        {
            var recurringTransaction = await GetRecurringTransaction(id);

            if (recurringTransaction == null)
                throw new KeyNotFoundException("RecurringTransaction does not exist");

            _context.RecurringTransactions.Remove(recurringTransaction);

            await _context.SaveChangesAsync();

            return recurringTransaction.RecurringTransactionId;
        }
        /// <summary>
        /// Retrieves if an recurringTransaction exists or not.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RecurringTransactionExists(Guid id)
        {
            return _context.RecurringTransactions.Any(e => e.RecurringTransactionId == id);
        }
    }
}
