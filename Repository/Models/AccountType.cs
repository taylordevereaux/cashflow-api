using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository.Models
{
    public partial class AccountType
    {
        public Guid AccountTypeId { get; set; }
        public string AccountTypeConstant { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
