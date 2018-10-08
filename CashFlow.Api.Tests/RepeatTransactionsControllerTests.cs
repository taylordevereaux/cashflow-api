using System;
using Xunit;

namespace CashFlow.Api.Tests
{
    public class RepeatTransactionsControllerTests
    {
        [Fact]
        public void Repeat_Daily()
        {
            var date = new DateTime(2018, 09, 15);
            var compare = new DateTime(2018, 10, 10);

            Assert.True(compare == date.Repeat(RepeatType.Daily, 25)
                        ,"Repeat Daily should only add x number of days.");
        }
        [Fact]
        public void Repeat_Weekly()
        {
            var date = new DateTime(2018, 09, 15);
            var compare = new DateTime(2018, 09, 29);

            Assert.True(compare == date.Repeat(RepeatType.Weekly, 2)
                , "Repeat Weekly should only add x*7 number of days.");
        }
        [Fact]
        public void Repeat_BiWeekly()
        {
            var date = new DateTime(2018, 09, 15);
            var compare = new DateTime(2018, 09, 29);

            Assert.True(compare == date.Repeat(RepeatType.BiWeekly, 1)
                , "Repeat BiWeekly should only add x*14 number of days.");
        }
        [Fact]
        public void Repeat_Monthly()
        {
            var date = new DateTime(2018, 09, 30);
            var compare = new DateTime(2018, 12, 30);

            Assert.True(compare == date.Repeat(RepeatType.Monthly, 3)
                , "Repeat Monthly should only add x number of months.");
        }
        [Fact]
        public void Repeat_Quarterly()
        {
            var date = new DateTime(2018, 09, 30);
            var compare = new DateTime(2019, 3, 30);

            Assert.True(compare == date.Repeat(RepeatType.Quarterly, 2)
                , "Repeat Quarterly should only add x*3 number of months.");
        }
        [Fact]
        public void Repeat_Yearly()
        {
            var date = new DateTime(2018, 09, 15);
            var compare = new DateTime(2028, 09, 15);

            Assert.True(compare == date.Repeat(RepeatType.Yearly, 10)
                , "Repeat Yearly should only add x number of years.");
        }

        [Fact]
        public void GetFirstDayOfMonth()
        {
            var date = new DateTime(2018, 09, 15, 23, 1, 23);
            var compare = new DateTime(2018, 09, 1, 23, 1, 23);

            Assert.True(compare == date.GetFirstDayOfMonth()
                , "GetFirstDayOfMonth must change the day to the first of the month. Preserving the Year, Month and time.");
        }
        [Fact]
        public void GetFirstDayAndTimeOfMonth()
        {
            var date = new DateTime(2018, 09, 15, 23, 1, 23);
            var compare = new DateTime(2018, 09, 1, 0, 0, 0);

            Assert.True(compare == date.GetFirstDayAndTimeOfMonth()
                , "GetFirstDayAndTimeOfMonth must change the day to the first of the month and the time to 12AM. Preserving only the Year and Month.");
        }
        [Fact]
        public void GetLastDayOfMonth()
        {
            var date = new DateTime(2018, 09, 15, 23, 1, 23);
            var compare = new DateTime(2018, 09, 30, 23, 1, 23);

            Assert.True(compare == date.GetLastDayOfMonth()
                , "GetLastDayOfMonth must change the day to the last of the month. Preserving the Year, Month and time.");
        }
        [Fact]
        public void GetLastDayAndTimeOfMonth()
        {
            var date = new DateTime(2018, 09, 15, 23, 1, 23);
            var compare = new DateTime(2018, 09, 30, 23, 59, 59);

            Assert.True(compare == date.GetLastDayAndTimeOfMonth()
                , "GetLastDayAndTimeOfMonth must change the day to the first of the month and the time to 12AM. Preserving only the Year and Month.");
        }
        [Fact]
        public void GetStartOfDay()
        {
            var date = new DateTime(2018, 09, 15, 12, 31, 23);
            var compare = new DateTime(2018, 09, 15, 00, 00, 00);

            Assert.True(compare == date.GetStartOfDay()
                , "GetStartOfDay must change the time to 00:00:00 while preserving the date.");
        }
        [Fact]
        public void GetEndOfDay()
        {
            var date = new DateTime(2018, 09, 15, 12, 31, 23);
            var compare = new DateTime(2018, 09, 15, 23, 59, 59);

            Assert.True(compare == date.GetEndOfDay()
                , "GetEndOfDay must change the time to 23:59:59 while preserving the date.");
        }
    }
}
