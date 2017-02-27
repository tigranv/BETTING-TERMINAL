using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TERMINAL // not comlited
{
    public static class TerminalAcync
    {
        public static async void SignOutAsync()
        {
            Task task = new Task(Terminal.SignOut);
            task.Start();
            await task;
            Console.WriteLine("User Signed out");
        }
    }
}
