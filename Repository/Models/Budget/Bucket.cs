using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Repository.Models.Budget
{
    public class Bucket
    {
        [Key]
        public Guid BucketId { get; set; }
        public string BucketConstant { get; set; }
        public decimal Percentage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}