using System;
using System.Threading.Tasks;
using Cashnflow.App;
using Cashnflow.App.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cashnflow.Cli
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            FinanceDBContext context = new FinanceDBContext();
            var repeatTransactions = await context.RepeatTransaction
                .Include(x => x.Account)
                .Include(x => x.RepeatType)
                .ToListAsync();

            try
            {
                foreach (var rt in repeatTransactions)
                {
                    System.Console.WriteLine($@"{rt.Account.Name} {rt.Amount}x{GetRepeatCount(rt.StartDate, rt.RepeatType.RepeatTypeConstant)} Repeating {rt.RepeatType.Name} starting {rt.StartDate.ToShortDateString()}");
                }

                System.Console.ReadKey();
            }
            catch ( Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static int GetRepeatCount(DateTime startDate, string repeatType)
        {
            int count = 0;
            switch (repeatType)
            {
                case "ONETIME":
                    count =  startDate < DateTime.Now ?  1 : 0;
                    break;
                case "DAILY":
                    count = startDate.DaysUntil(DateTime.Now);
                    break;
                case "WEEKLY":
                    count = startDate.WeeksUntil(DateTime.Now);
                    break;
                case "BIWEEKLY":
                    count = startDate.WeeksUntil(DateTime.Now) / 2;
                    break;
                case "MONTHLY":
                    count = startDate.MonthsUntil(DateTime.Now);
                    break;
                case "YEARLY":
                    count = startDate.YearsUntil(DateTime.Now);
                    break;
                default:
                    return 0;
            }
            return count + 1;
        }
    }
}
