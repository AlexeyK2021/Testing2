using System;

namespace Test3
{
    public class Admin : Account
    {
        public Admin(string userName, string password) : base(userName, password)
        {
        }

        public override void OutputControl()
        {
            Console.WriteLine(
                "Press S to send Set request\n Press G to send Get request\nPress K to show stats\nPress I to show accounts");
        }

        private void GetRequests()
        {
            if (Service.requests.Count > 0)
            {
                for (int i = 0; i < Service.requests.Count; i += 2)
                {
                    Console.WriteLine($"Request TYPE: {Service.requests[i + 1]} from {Service.requests[i]}");
                }
            }
            else Console.WriteLine("0 Requests");
        }

        private static void GetAccounts()
        {
            if (Service.Accounts.Count > 0)
            {
                foreach (var acc in Service.Accounts)
                {
                    string status = acc is Admin ? "Admin " : "User";
                    Console.WriteLine(acc.GetUserName() + "\t " + status);
                }
            }
            else Console.WriteLine("You haven't created any account yet!");
        }

        public override void Update(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.K:
                    new Service().GetStats();
                    break;
                case ConsoleKey.I:
                    GetAccounts();
                    break;
                case ConsoleKey.R:
                    GetRequests();
                    break;
                default: break;
            }
        }
    }
}