using System;
using System.Collections.Generic;

namespace Cashnflow.Repository
{
    public partial class Account
    {
        public Account()
        {
            RepeatTransaction = new HashSet<RepeatTransaction>();
        }

        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }

        public AccountType AccountType { get; set; }
        public ICollection<RepeatTransaction> RepeatTransaction { get; set; }
    }
}
