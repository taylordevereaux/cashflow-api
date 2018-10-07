using System;
using System.Collections.Generic;
using System.Text;

namespace Cashnflow.Api
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
                    date = date.AddDays(1 * repeatCount);
                    break;
                case RepeatType.Weekly:
                    date = date.AddDays(7 * repeatCount);
                    break;
                case RepeatType.BiWeekly:
                    date = date.AddDays(14 * repeatCount);
                    break;
                case RepeatType.Monthly:
                    date = date.AddMonths(1 * repeatCount);
                    break;
                case RepeatType.Quarterly:
                    date = date.AddMonths(3 * repeatCount);
                    break;
                case RepeatType.Yearly:
                    date = date.AddYears(1 * repeatCount);
                    break;
            }
            return date;
        }

        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            date = date.AddMonths(1);
            date = date.AddDays(-date.Day);
            return date;
        }
        public static DateTime GetLastDayAndTimeOfMonth(this DateTime date)
        {
            date = date.AddMonths(1);
            date = date.GetFirstDayAndTimeOfMonth();
            return date.AddSeconds(-1);
        }
        /// <summary>
        /// Sets the current dates day to the first of the month. Not effecting the time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            return date.AddDays(-(date.Day - 1));
        }
        /// <summary>
        /// Sets the current dates day to the first of the month. Effecting the time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayAndTimeOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
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
