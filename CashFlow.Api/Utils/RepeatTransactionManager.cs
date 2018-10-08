using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CashFlow.Api.Models;
using CashFlow.Api.Repository;

namespace CashFlow.Api.Utils
{
    public class RepeatTransactionManager
    {
        public static IEnumerable<Transaction> RepeatTransaction(RepeatTransaction repeatTransaction, int times)
        {
            for (int i = 0; i < times; ++i)
            {
                var date = repeatTransaction.StartDate.Repeat(Enum.Parse<RepeatType>(repeatTransaction.RepeatType.RepeatTypeConstant,
                    true), 1);
                yield return new Transaction()
                {
                    Amount = repeatTransaction.Amount,
                    TransactionDate = date
                };
            }
        }
    }
}
