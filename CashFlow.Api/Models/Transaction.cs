using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Api.Models
{
    public class Transaction
    {
        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }
    }
}
