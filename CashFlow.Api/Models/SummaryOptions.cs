using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Api.Models
{
    public class SummaryOptions
    {
        public int? AccountId { get; set; }

        public DateTime? StartDate { get; set; }

        public Recurrence Recurrence { get; set; }
        [Range(1, 365)]
        public int RecurrenceMultiplier { get; set; } = 1;

        [Range(1, 12)]
        public int RecurrenceCount { get; set; } = 1;
    }
}
