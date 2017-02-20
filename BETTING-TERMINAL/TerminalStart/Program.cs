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
            Terminal.Registration(player2, Currency.USD);

            Console.WriteLine("Enter name and password to Sign in");
            Console.Write("Name - ");
            string name = Console.ReadLine();
            Console.Write("Password - ");
            string password = Console.ReadLine();

            Terminal.SignIn(name, password);

            Terminal.SignOut();
            Terminal.AddMoney(new Money(100, Currency.AMD));


            Terminal.SignIn(name, password);

            Terminal.AddMoney(new Money(100, Currency.AMD));
            Terminal.Bet(new Money(80, Currency.AMD));
            Terminal.Bet(new Money(50, Currency.AMD));




            Console.ReadKey();
        }
    }
}
