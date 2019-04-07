using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class Account
    {
        public Account()
        {
            RecurringTransaction = new HashSet<RecurringTransaction>();
            Transaction = new HashSet<Transaction>();
        }

        public Guid AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal StartingAmount { get; set; }
        public DateTime CreatedDate { get; set; }

        public AccountType AccountType { get; set; }
        public ICollection<RecurringTransaction> RecurringTransaction { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
