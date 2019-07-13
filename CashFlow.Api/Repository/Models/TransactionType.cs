using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
        }
        public Guid TransactionTypeId { get; set; }
        public string TransactionTypeConstant { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
