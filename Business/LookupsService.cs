using CashFlow.Api.Repository;
using CashFlow.Api.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Api.Business
{
    /// <summary>
    /// Manager class for Lookup Records.
    /// </summary>
    public class LookupsService
    {
        private readonly CashFlowDbContext _context;

        public LookupsService(CashFlowDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionType>> GetTransactionTypes()
        {
            return await _context
                .TransactionTypes
                .OrderBy(x => x.Name)
                .ToListAsync();
        }


        public async Task<IEnumerable<AccountType>> GetAccountTypes()
        {
            return await _context
                .AccountTypes
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
