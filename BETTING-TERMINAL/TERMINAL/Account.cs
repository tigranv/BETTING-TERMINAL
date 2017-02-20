using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    public class Account
    {
        public Player player { get; private set; }
        public Currency currency { get; private set; }
        public decimal Balance { get; private set; }
        int password;

        public Account(Player player, Currency currency, int pass)
        {
            this.player = player;
            this.currency = currency;
            Balance = 0;
            password = pass;
        }
    }
}
