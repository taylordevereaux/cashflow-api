using System;
using System.Collections.Generic;
using System.Text;

namespace Cashnflow.App
{
    public static class RecurringDateTimeExtension
    {
        public enum RepeatType
        {
            Daily,
            Weekly,
            BiWeekly,
            Monthly,
            Quarterly,
            Yearly
        };

        public static IEnumerable<DateTime> RecurrencesUntil(this DateTime date, RepeatType repeat, DateTime endDate)
        {
            DateTime repeatDate = date;

            do
            {
                yield return repeatDate = repeatDate.Repeat(repeat, 1);
            }
            while (repeatDate < endDate);
        }

        public static DateTime Repeat(this DateTime date, RepeatType repeat, int repeatCount)
        {
            switch (repeat)
            {
                case RepeatType.Daily:
                    date.AddDays(1 * repeatCount);
                    break;
                case RepeatType.Weekly:
                    date.AddDays(7 * repeatCount);
                    break;
                case RepeatType.BiWeekly:
                    date.AddDays(14 * repeatCount);
                    break;
                case RepeatType.Monthly:
                    date.AddMonths(1 * repeatCount);
                    break;
                case RepeatType.Quarterly:
                    date.AddMonths(3 * repeatCount);
                    break;
                case RepeatType.Yearly:
                    date.AddYears(1* repeatCount);
                    break;
            }
            return date;
        }

        //public static int DaysUntil(this DateTime currentDate, DateTime date)
        //{
        //    return (date - currentDate).Days;
        //}

        //public static int WeeksUntil(this DateTime currentDate, DateTime date)
        //{
        //    return (currentDate.DaysUntil(date) / 7);
        //}

        //public static int MonthsUntil(this DateTime currentDate, DateTime date)
        //{
        //    int years = date.Year - currentDate.Year;
        //    int months = date.Month - currentDate.Month;

        //    int count = years * 12;
        //    count += months;
        //    if (currentDate.Day > date.Day)
        //        count--;
        //    return count;
        //}

        //public static int YearsUntil(this DateTime currentDate, DateTime date)
        //{
        //    int count = date.Year - currentDate.Year;
        //    if (currentDate.Month < date.Month)
        //        count++;
        //    return count;
        //}
    }
}
