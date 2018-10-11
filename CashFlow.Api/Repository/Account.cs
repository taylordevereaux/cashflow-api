using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class Account
    {
        public Account()
        {
            RecurringTransaction = new HashSet<RecurringTransaction>();
        }

        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public AccountType AccountType { get; set; }
        public ICollection<RecurringTransaction> RecurringTransaction { get; set; }
    }
}
