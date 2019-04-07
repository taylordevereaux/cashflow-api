using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public Account Account { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
