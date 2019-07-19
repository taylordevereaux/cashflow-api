using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository.Models
{
    public partial class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid TransactionTypeId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
