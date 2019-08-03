using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Api.Repository.Models
{
    public partial class Account
    {
        public Account()
        {
            RecurringTransactions = new HashSet<RecurringTransaction>();
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public Guid AccountId { get; set; }
        public Guid AccountTypeId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal StartingAmount { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(Account.AccountTypeId))]
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<RecurringTransaction> RecurringTransactions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
