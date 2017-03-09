# BETTING-TERMINAL <img src="https://cloud.githubusercontent.com/assets/24522089/21962098/41a510c8-db36-11e6-95ef-eb392a0a1919.png" align="right" width="130px" height="130px" /> 

Class Library Betting Terminal Provides: Player Registration, Adding Money to Account, Betting, Checking Balance Sign in Sign out

### TPL part NOT Completed!

```c#
using System;
using TERMINAL;

namespace TerminalStart
{
    class Program
    {
        static void Main(string[] args)
        {     
            Terminal.Registration("Sashik", "Sargsyan", new DateTime(1960, 10, 15), Currency.AMD);
            Terminal.Registration("Robert", "Qocharyan", new DateTime(1955, 1, 5), Currency.USD);
            // passwords must be sended to emails, or messaged to phone number(Not complited)

            Console.WriteLine("Enter name and password to Sign in");
            Console.Write("Name - ");
            string name1 = Console.ReadLine();
            Console.Write("Password - ");
            string password1 = Console.ReadLine();

            // Signing In
            Terminal.SignIn(name1, password1);
            // Signing out
            Terminal.SignOut();

            // Trying to add money without signing in(not permited)
            Terminal.AddMoney(new Money(100, Currency.AMD));

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
```

> The output is:

![betting_terminal](https://cloud.githubusercontent.com/assets/24522089/23565164/db905e96-0065-11e7-8bdb-4b725ffe958c.gif)

> This project is written on C# 6.0, .NET Framework 4.6 Visual Studio 2015 Comunity Edition
