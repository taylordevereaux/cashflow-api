using System;
using System.Collections.Generic;
using System.Text;

namespace Cashnflow.Core
{
    public static class RecurringDatesExtensions
    {
        public static int DaysUntil(this DateTime currentDate, DateTime date)
        {
            return (date - currentDate).Days;
        }

        public static int WeeksUntil(this DateTime currentDate, DateTime date)
        {
            return (currentDate.DaysUntil(date) / 7);
        }

        public static int MonthsUntil(this DateTime currentDate, DateTime date)
        {
            int years = date.Year - currentDate.Year;
            int months = date.Month - currentDate.Month;

            int count = years * 12;
            count += months;
            if (currentDate.Day > date.Day)
                count--;
            return count;
        }

        public static int YearsUntil(this DateTime currentDate, DateTime date)
        {
            int count = date.Year - currentDate.Year;
            if (currentDate.Month < date.Month)
                count++;
            return count;
        }
    }
}
