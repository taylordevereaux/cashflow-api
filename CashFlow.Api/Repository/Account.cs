using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class Account
    {
        public Account()
        {
            RecurringTransactions = new HashSet<RecurringTransaction>();
            Transactions = new HashSet<Transaction>();
        }

        public Guid AccountId { get; set; }
        public Guid AccountTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal StartingAmount { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<RecurringTransaction> RecurringTransactions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
