using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RecurrenceAmount { get; set; }
        public string RecurrenceType { get; set; }
        public int? DayOfMonth { get; set; }
        public string Ordinal { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime CreatedDate { get; set; }

        public RecurringTransaction RecurringTransaction { get; set; }
    }
}
