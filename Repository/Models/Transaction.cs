using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Api.Repository.Models
{
    public partial class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid TransactionTypeId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey(nameof(Transaction.AccountId))]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(Transaction.TransactionTypeId))]
        public virtual TransactionType TransactionType { get; set; }
    }
}
