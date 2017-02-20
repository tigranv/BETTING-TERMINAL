using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL
{
    public static class Terminal
    {
        static decimal currentBalance;
        static List<Account> AccountsData = new List<Account>();
        static bool Status = false;
        static Account SignedAccount = null;

        public static void Registration(Player pl, Currency cur)
        {
            string password = NewPassword();
            Account newAccount = new Account(pl, cur, password);
            AccountsData.Add(newAccount);
            Console.WriteLine($"New Player Registered, {pl.ToString()}.\nThe password is -----> {password}");
        }

        public static void SignIn(string name, string pass)
        {
            if (Status) { Console.WriteLine("You can't sign in");  return; };
            Status = true;
            SignedAccount = AccountsData.Find(x => (x.player.FirstName == name) && (x.password == pass));
            if(SignedAccount != null)
            Console.WriteLine($"Player, {SignedAccount.player.ToString()} Signed In");
            else
            {
                Console.WriteLine("Not registered account, or wrong password");
            }
        }

        public static void SignOut()
        {
            Status = false;
        }



        public static void AddMoney( Money money)
        {
            if (!Status) { Console.WriteLine("You can't sign in"); return; };
            Console.WriteLine("Add  money working");
            currentBalance = SignedAccount.Balance + money.Amount;
        }

        static void Bet(Account account, Money money)
        {
            if (!Status) { Console.WriteLine("You can't sign in"); return; };

            currentBalance = account.Balance + money.Amount;
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
