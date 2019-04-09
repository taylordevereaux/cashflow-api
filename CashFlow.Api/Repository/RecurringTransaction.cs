using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class RecurringTransaction
    {
        public Guid RecurringTransactionId { get; set; }
        public Guid TransactionTypeId { get; set; }
        public Guid AccountId { get; set; }
        public Guid? ScheduleId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
