using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    public static class Terminal
    {
        static decimal currentBalance;

        static void AddMoney(Account account, Money money)
        {
            currentBalance = account.Balance + money.Amount;

        }
    }
}
