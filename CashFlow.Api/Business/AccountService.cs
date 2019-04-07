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
    public class AccountService
    {
        private readonly CashFlowDBContext _context;

        public AccountService(CashFlowDBContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccount(Guid accountID)
        {
            return await _context
                .Account
                .FindAsync(accountID);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context
                .Account
                .ToListAsync();
        }

        public async Task<Guid> CreateAccount(Account account)
        {
            var result = await _context.Account.AddAsync(account);

            await _context.SaveChangesAsync();

            return result.Entity.AccountId;
        }

        public async Task<Guid> UpdateAccount(Account account)
        {
            _context.Account.Update(account);

            await _context.SaveChangesAsync();

            return account.AccountId;
        }

        public async Task<Guid> DeleteAccount(Guid accountId)
        {
            var account = await GetAccount(accountId);

            if (account == null)
                throw new KeyNotFoundException("Account does not exist");

            _context.Account.Remove(account);

            await _context.SaveChangesAsync();

            return account.AccountId;
        }
    }
}
