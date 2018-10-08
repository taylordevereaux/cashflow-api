using System;
using System.Collections.Generic;

namespace CashFlow.Api
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

    public static class RecurringDateTimeExtension
    {
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

        /// <summary>
        /// Sets the date to the last day of the current month. Preserving the time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            date = date.AddMonths(1);
            date = date.AddDays(-date.Day);
            return date;
        }
        /// <summary>
        /// Sets the date to the last day of the current month. Setting the time to 23:59:59.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDayAndTimeOfMonth(this DateTime date)
        {
            date = date.AddMonths(1);
            date = date.GetFirstDayAndTimeOfMonth();
            return date.AddSeconds(-1);
        }
        /// <summary>
        /// Sets the date to the first of the current month. Preserving the time.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            return date.AddDays(-(date.Day - 1));
        }
        /// <summary>
        /// Sets the date to the first of the month. Setting the time to 00:00:00.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayAndTimeOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0);
        }
        /// <summary>
        /// Returns the same date with a time of 00:00:00.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetStartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        /// <summary>
        /// Returns the same date with a time of 23:59:59.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetEndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }
    }
}
