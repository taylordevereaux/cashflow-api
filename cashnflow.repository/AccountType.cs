using System;
using System.Collections.Generic;

namespace Cashnflow.Repository
{
    public partial class AccountType
    {
        public AccountType()
        {
            Account = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public string AccountTypeConstant { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}
