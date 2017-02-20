using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    internal class EventArgsBalance: EventArgs
    {
        public decimal currentBalance { get; set; }
    }
}
