using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            RecurringTransactions = new HashSet<RecurringTransaction>();
            Transactions = new HashSet<Transaction>();
        }

        public Guid TransactionTypeId { get; set; }
        public string TransactionTypeConstant { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<RecurringTransaction> RecurringTransactions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
