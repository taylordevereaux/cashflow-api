using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Api.Repository.Models
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

        [ForeignKey(nameof(RecurringTransaction.AccountId))]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(RecurringTransaction.ScheduleId))]
        public virtual Schedule Schedule { get; set; }
        [ForeignKey(nameof(RecurringTransaction.TransactionTypeId))]
        public virtual TransactionType TransactionType { get; set; }
    }
}
