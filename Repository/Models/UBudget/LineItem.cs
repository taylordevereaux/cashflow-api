using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Repository.Models.UBudget
{
    public class LineItem
    {
        [Key]
        public Guid LineItemId { get; set; }
        public bool IsIncome { get; set; }
        public decimal FixedAmount { get; set; }
        public string Name { get; set; }
        public Guid UserBucketId { get; set; }
        public Guid UserId { get; set; }
    }
}