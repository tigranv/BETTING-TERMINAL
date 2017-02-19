using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    public class Money
    {
        public decimal Amount { get; set; }
        public Currency Curency { get; set; }
        public Money(decimal amount, Currency cur)
        {
            Amount = amount;
            Curency = cur;
        }
    }
}
