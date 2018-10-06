using System;
using System.Collections.Generic;

namespace Cashnflow.Api.Repository
{
    public partial class RepeatTransaction
    {
        public int RepeatTransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public int? RepeatTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public Account Account { get; set; }
        public RepeatType RepeatType { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
