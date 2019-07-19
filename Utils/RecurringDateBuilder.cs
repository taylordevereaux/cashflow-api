using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Api.Repository;
using CashFlow.Api.Repository.Models;
using Dates.Recurring;
using Dates.Recurring.Type;

namespace CashFlow.Api.Utils
{
    /// <summary>
    /// Builds a RecurringDate based on the parameters passed.
    /// </summary>
    public class RecurringDateBuilder
    {
        public static Dates.Recurring.Type.RecurrenceType Build(Schedule schedule)
        {
            switch (schedule.RecurrenceType.ToLower())
            {
                case "daily":
                    return BuildDaily(schedule);
                case "weekly":
                    return BuildWeekly(schedule);
                case "monthly":
                    return BuildMonthly(schedule);
                case "yearly":
                    return BuildYearly(schedule);
                default:
                    throw new InvalidEnumArgumentException("Schedule.RecurrenceType");
            }
        }

        private static Daily BuildDaily(Schedule schedule)
        {
            return Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecurrenceAmount)
                .Days()
                .Ending(schedule.EndDate)
                .Build();
        }

        private static Weekly BuildWeekly(Schedule schedule)
        {
            return Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecurrenceAmount)
                .Weeks()
                .OnDay(schedule.StartDate.DayOfWeek)
                .Ending(schedule.EndDate)
                .Build();
        }

        private static Monthly BuildMonthly(Schedule schedule)
        {
            var month = Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecurrenceAmount)
                .Months();


            if (schedule.Ordinal != null && schedule.DayOfWeek != null)
            {
                return month
                    .OnOrdinalWeek(Enum.Parse<Ordinal>(schedule.Ordinal, true))
                    .OnDay(Enum.Parse<DayOfWeek>(schedule.DayOfWeek, true))
                    .Build();
            }
            else
            {
                if (schedule.DayOfMonth == null)
                    schedule.DayOfMonth = schedule.StartDate.Day;

                return month
                    .OnDay(schedule.DayOfMonth.Value)
                    .Ending(schedule.EndDate)
                    .Build();
            }
        }

        private static Yearly BuildYearly(Schedule schedule)
        {
            return Recurs
                .Starting(schedule.StartDate)
                .Every(schedule.RecurrenceAmount)
                .Years()
                .OnDay(schedule.StartDate.Day)
                .OnMonth(schedule.StartDate)
                .Ending(schedule.EndDate)
                .Build();
        }
    }

}
