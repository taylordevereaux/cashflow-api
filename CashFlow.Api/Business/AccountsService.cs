using CashFlow.Api.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Api.Business
{
    /// <summary>
    /// Manager class for Account Records.
    /// </summary>
    public class AccountsService
    {
        private readonly CashFlowDBContext _context;

        public AccountsService(CashFlowDBContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccount(Guid accountId)
        {
            var account = await _context
                .Accounts
                .Include(x => x.AccountType)
                .Include(x => x.Transactions)
                .SingleOrDefaultAsync(x => x.AccountId == accountId);

            account.RecurringTransactions = await _context
                .RecurringTransactions
                .Include(x => x.TransactionType)
                .Include(x => x.Schedule)
                .Where(x => x.AccountId == accountId)
                .ToListAsync();

            return account;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context
                .Accounts
                .ToListAsync();
        }

        public async Task<Guid> CreateAccount(Account account)
        {
            // Defaulting Initial Values.
            account.CreatedDate = DateTime.Now;
            account.Amount = account.StartingAmount;

            var result = _context.Accounts.Add(account);

            await _context.SaveChangesAsync();

            return result.Entity.AccountId;
        }

        public async Task<Guid> UpdateAccount(Account account)
        {

            _context.Accounts.Update(account);

            await _context.SaveChangesAsync();

            return account.AccountId;
        }

        public async Task<Guid> DeleteAccount(Guid accountId)
        {
            var account = await GetAccount(accountId);

            if (account == null)
                throw new KeyNotFoundException("Account does not exist");

            _context.Accounts.Remove(account);

            await _context.SaveChangesAsync();

            return account.AccountId;
        }
        /// <summary>
        /// Retrieves if an account exists or not.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AccountExists(Guid id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
