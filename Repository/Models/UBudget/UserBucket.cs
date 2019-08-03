using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CashFlow.Repository.Models.Budget;

namespace CashFlow.Repository.Models.UBudget
{
    public class UserBucket
    {
        [Key]
        public Guid UserBucketId { get; set; }
        public int Percentage { get; set; }
        public Guid UserId { get; set; }
        public Guid BucketId { get; set; }
        [ForeignKey("BucketId")]
        public Bucket Bucket { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
}