using System;
using System.Threading.Tasks;
using TERMINAL;

namespace TerminalStart
{
    class Program
    {
        static void Main(string[] args)
        {                        
            Terminal.Registration("Sashik", "Sargsyan", new DateTime(2000, 10, 15), Currency.AMD);
            Terminal.Registration("Robert", "Qocharyan", new DateTime(1955, 1, 5), Currency.USD);
            // passwords must be sended to emails, or messaged to phone number(not complited)

            Console.WriteLine("Enter name and password to Sign in");
            Console.Write("Name - ");
            string name1 = Console.ReadLine();
            Console.Write("Password - ");
            string password1 = Console.ReadLine();

            // Signing In
            Terminal.SignIn(name1, password1);
            // Signing out (trying to organize async )
            Action signout = Terminal.SignOut;
            Task task = new Task(signout);
            task.Start();
            task.Wait();
            //Terminal.SignOut();
            //TerminalAcync.SignOutAsync();

            // Trying to add money without signing in(not permited)
            Terminal.AddMoney(new Money(100, Currency.AMD));

            // TODO: Adding advertising movie while signing in using asinc await

            // Signing In again
            Terminal.SignIn(name1, password1);

            // Account balance checking
            Terminal.ShowBallance();

            // Adding money(100AMD) to account balance, will show current balance
            Terminal.AddMoney(new Money(100, Currency.AMD));

            // betting 80AMD
            Terminal.Bet(new Money(80, Currency.AMD));

            // betting 50AMD, (not permited, no enough money)
            Terminal.Bet(new Money(50, Currency.AMD));

            // Again addding and betting
            Terminal.AddMoney(new Money(100, Currency.AMD));
            Terminal.Bet(new Money(50, Currency.AMD));

            Console.ReadKey();
        }
    }
}
