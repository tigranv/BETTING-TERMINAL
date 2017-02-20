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

        public static void Registration(Player pl, Currency cur)
        {
            AccountsData.Add(new Account(pl, cur, NewPassword()));
            Console.WriteLine($"Password sended to your email, password is - {NewPassword()}");
        }

        static void AddMoney(Account account, Money money)
        {
            currentBalance = account.Balance + money.Amount;
        }


        public static string NewPassword()
        {
            char[] newpassword = new char[8];
            string hex = "0123456789abcdefABCDEF";
            byte[] data = new byte[newpassword.Length];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(data);
            var seed = BitConverter.ToInt32(data, 0);
            var rnd = new Random(seed);
            for (int i = 0; i < 8; i++)
            {
                newpassword[i] = hex[rnd.Next(0, hex.Length - 1)];
            }
            return new string(newpassword);
        }
    }
}
