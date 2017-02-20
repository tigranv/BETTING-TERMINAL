using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    internal class Account
    {
        public Player player { get; private set; }
        public Currency currency { get; private set; }
        public decimal Balance { get; private set; }
        public string password;

        public Account(Player player, Currency currency, string pass)
        {
            this.player = player;
            this.currency = currency;
            Balance = 0;
            password = pass;
            Terminal.balanceRefreshe += Fill;
        }

        void Fill(object obj, EventArgs args)
        {
            Account CurrentAccount = obj as Account;
            EventArgsBalance AddedMoney = args as EventArgsBalance;
            CurrentAccount.Balance = AddedMoney.currentBalance;
        }
    }
}
