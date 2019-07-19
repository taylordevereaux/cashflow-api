using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dates.Recurring.Type;

namespace CashFlow.Api.Extensions
{
    public static class RecurrenceTypeExtensions
    {
        public static List<DateTime> Until(this RecurrenceType recurrence, DateTime after, DateTime end)
        {
            var dates = new List<DateTime>();
            while (after < end)
            {
                var next = recurrence.Next(after);
                if (next == null || next > end)
                    break;
                else
                    dates.Add(next.Value);
                after = next.Value;
            }
            return dates;
        }
        public static List<DateTime> Until(this RecurrenceType recurrence, DateTime after, int times)
        {
            var dates = new List<DateTime>();
            int count = 0;
            while (count < times)
            {
                var next = recurrence.Next(after);
                if (next == null)
                    break;
                else
                    dates.Add(next.Value);
                after = next.Value;
                ++count;
            }
            return dates;
        }
    }
}
