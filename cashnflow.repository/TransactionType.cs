using System;
using System.Collections.Generic;

namespace Cashnflow.Repository
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            RepeatTransaction = new HashSet<RepeatTransaction>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionTypeConstant { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<RepeatTransaction> RepeatTransaction { get; set; }
    }
}
