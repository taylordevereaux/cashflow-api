using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Api.Models;
using Dates.Recurring;
using Dates.Recurring.Type;
using Ordinal = Dates.Recurring.Ordinal;
using RecurrenceType = CashFlow.Api.Models.RecurrenceType;

namespace CashFlow.Api.Utils
{
    /// <summary>
    /// Builds a RecurringDate based on the parameters passed.
    /// </summary>
    public class RecurringDateBuilder
    {
        public static Dates.Recurring.Type.RecurrenceType Build(Schedule schedule)
        {
            switch (schedule.RecurrenceType)
            {
                case RecurrenceType.Daily:
                    return BuildDaily(schedule);
                case RecurrenceType.Weekly:
                    return BuildWeekly(schedule);
                case RecurrenceType.Monthly:
                    return BuildMonthly(schedule);
                case RecurrenceType.Yearly:
                    return BuildYearly(schedule);
                default:
                    throw new InvalidEnumArgumentException("Schedule.RecurrenceType");
            }
        }

        private static Daily BuildDaily(Schedule schedule)
        {
            return Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecursEveryAmount)
                .Days()
                .Ending(schedule.EndDate ?? DateTime.MaxValue)
                .Build();
        }

        private static Weekly BuildWeekly(Schedule schedule)
        {
            return Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecursEveryAmount)
                .Weeks()
                .OnDay(schedule.StartDate.DayOfWeek)
                .Ending(schedule.EndDate ?? DateTime.MaxValue)
                .Build();
        }

        private static Monthly BuildMonthly(Schedule schedule)
        {
            var month = Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecursEveryAmount)
                .Months();
            if (schedule.DayOfMonth != null)
            {
                return month
                    .OnDay(schedule.DayOfMonth.Value)
                    .Ending(schedule.EndDate ?? DateTime.MaxValue)
                    .Build();
            }
            else
            {
                return month
                    .OnOrdinalWeek(Enum.Parse<Ordinal>(schedule.Ordinal.Value.ToString(), true))
                    .OnDay(schedule.DayOfWeek.Value)
                    .Build();
            }
        }

        private static Yearly BuildYearly(Schedule schedule)
        {
            return Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecursEveryAmount)
                .Years()
                .Build();
        }
    }

}
