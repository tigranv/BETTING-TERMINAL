using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TERMINAL
{


    public static class Terminal
    {
        static List<Account> AccountsData = new List<Account>();
        static bool TerminalStatus = false;
        static Account SignedAccount = null;
        public static event EventHandler<EventArgsBalance> balanceRefreshe;
        static decimal currentBalance = 0;


        public static void Registration(string firstName, string lastName, DateTime birtDate, Currency cur)
        {
            try
            {
                Player pl = new Player(firstName, lastName, birtDate);
                string password;
                do
                {
                    password = NewPassword();
                }
                while (AccountsData.Find(x => x.password == password) != null);

                Account newAccount = new Account(pl, cur, password);
                AccountsData.Add(newAccount);
                Console.WriteLine($"New Player {pl.ToString()} Registered: \t The password is -----> {password}");
            }
            catch (AgeExeption ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void SignIn(string name, string pass)
        {
            Thread.Sleep(5000);
            if (TerminalStatus) { Console.WriteLine("You can't sign in");  return; };
            SignedAccount = AccountsData.Find(x => (x.player.FirstName == name) && (x.password == pass));
            if(SignedAccount != null)
            {
                Console.WriteLine($"Player {SignedAccount.player.ToString()} Signed In");
                TerminalStatus = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not registered account, or wrong password");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public static void SignOut()
        {
            TerminalStatus = false;
            if (SignedAccount == null) return;
            Console.WriteLine($"Player {SignedAccount.player.ToString()} Signed Out");
            SignedAccount = null;
        }

        public static void ShowBallance()
        {
            if (!TerminalStatus) { Console.WriteLine("Sign in to check balance"); return; }
            Console.WriteLine($"Balance of {SignedAccount.player.FirstName} is {SignedAccount.Balance}{SignedAccount.currency}");
        }

        public static void AddMoney(Money money)
        {
            if (!TerminalStatus) { Console.WriteLine("Error - Adding money Faild - Not Signed Account"); return; };
            if (money.Curency != SignedAccount.currency) { Console.WriteLine($"Error(Can't Add money) Account currency is in {SignedAccount.currency}"); return; };
            currentBalance = SignedAccount.Balance + money.Amount;
            balanceRefreshe(SignedAccount, new EventArgsBalance(currentBalance));
            Console.WriteLine($"{money.Amount} {money.Curency} money added to Your account, Your balance is Now {SignedAccount.Balance} {money.Curency}.");
        }

        public static void Bet(Money money)
        {
            if (!TerminalStatus) { Console.WriteLine("Error - betting Faild - Not Signed Account"); return; };
            if (money.Curency != SignedAccount.currency) { Console.WriteLine($"Error(Can't Bet) Account currency is in {SignedAccount.currency}"); return; };
            Console.WriteLine($"Betting {money.Amount} {money.Curency} to . . . .");
            if (SignedAccount.Balance - money.Amount >= 0)
            {
                currentBalance = SignedAccount.Balance - money.Amount;
                balanceRefreshe(SignedAccount, new EventArgsBalance(currentBalance));
                Console.WriteLine($"{money.Amount} {money.Curency} money beted Your balance is Now {SignedAccount.Balance} {money.Curency}.");
            }
            else Console.WriteLine($"Betting Faild: You have no enough money on your account. ");            
        }

        private static string NewPassword()
        {
            char[] newpassword = new char[4];
            string hex = "0123456789ABCDEF";
            byte[] data = new byte[newpassword.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < 4; i++)
            {
                newpassword[i] = hex[rnd.Next(0, hex.Length - 1)];
            }
            return new string(newpassword);
        }
    }

}
