using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            RecurringTransaction = new HashSet<RecurringTransaction>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionTypeConstant { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<RecurringTransaction> RecurringTransaction { get; set; }
    }
}
