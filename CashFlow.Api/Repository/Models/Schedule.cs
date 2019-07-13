using System;
using System.Collections.Generic;

namespace CashFlow.Api.Repository.Models
{
    public partial class Schedule
    {
        public Guid ScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RecurrenceAmount { get; set; }
        public string RecurrenceType { get; set; }
        public int? DayOfMonth { get; set; }
        public string Ordinal { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual RecurringTransaction RecurringTransaction { get; set; }
    }
}
