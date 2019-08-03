using System;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Repository.Models.Budget
{
    public class Bucket
    {
        [Key]
        public Guid BucketId { get; set; }
        public string BucketConstant { get; set; }
        public int Percentage { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}