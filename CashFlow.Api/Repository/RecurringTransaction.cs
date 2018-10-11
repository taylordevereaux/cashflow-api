using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class RecurringTransaction
    {
        public int RecurringTransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public int? ScheduleId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public Account Account { get; set; }
        public Schedule Schedule { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
