using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.Api.Models
{
    public class Schedule
    {
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int RecursEveryAmount { get; set; } = 1;

        public RecurrenceType RecurrenceType { get; set; }
        [MinLength(1)]
        [MaxLength(28)]
        public int? DayOfMonth { get; set; }

        public Ordinal? Ordinal { get; set; }

        public DayOfWeek? DayOfWeek { get; set; }
    }

    public enum RecurrenceType
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum Ordinal
    {
        First,
        Second,
        Third,
        Forth,
        Last
    }
}
