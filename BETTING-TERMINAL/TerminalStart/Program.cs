using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TERMINAL;

namespace TerminalStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Sashik", "Sargsyan", new DateTime(1990, 10, 15));
            Player player2 = new Player("Robert", "Qocharyan", new DateTime(1995, 1, 5));

            Terminal.Registration(player1, Currency.AMD);

            Console.ReadKey();
        }
    }
}
