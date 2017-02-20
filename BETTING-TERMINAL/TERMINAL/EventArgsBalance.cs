using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    public class EventArgsBalance: EventArgs
    {
        public decimal currentBalance { get; set; }
        public EventArgsBalance(decimal bal)
        {
            currentBalance = bal;
        }
    }
}
