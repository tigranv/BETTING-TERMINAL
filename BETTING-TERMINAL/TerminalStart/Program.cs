using System;
using TERMINAL;

namespace TerminalStart
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Terminal.Registration("Sashik", "Sargsyan", new DateTime(2010, 10, 15), Currency.AMD);
            Terminal.Registration("Robert", "Qocharyan", new DateTime(1995, 1, 5), Currency.USD);
            // passwords must be sended to emails, or messaged to phone number
            Console.WriteLine("Enter name and password to Sign in");
            Console.Write("Name - ");
            string name1 = Console.ReadLine();
            Console.Write("Password - ");
            string password1 = Console.ReadLine();

            Terminal.SignIn(name1, password1);

            Terminal.SignOut();
            Terminal.AddMoney(new Money(100, Currency.AMD));


            Terminal.SignIn(name1, password1);

            Terminal.ShowBallance();

            Terminal.AddMoney(new Money(100, Currency.AMD));

            Terminal.Bet(new Money(80, Currency.AMD));

            Terminal.Bet(new Money(50, Currency.AMD));

            Terminal.AddMoney(new Money(100, Currency.AMD));

            Terminal.Bet(new Money(50, Currency.AMD));






            Console.ReadKey();
        }
    }
}
