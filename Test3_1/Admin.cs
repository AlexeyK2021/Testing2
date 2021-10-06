using System;
using System.Collections.Generic;

namespace Test3_1
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
        
        private static void GetAccounts(List<Service> services)
        {
            int accounts = 0;
            foreach (var service in services)
            {
                if (service.Accounts.Count > 0)
                {
                    foreach (var acc in service.Accounts)
                    {
                        string status = acc is Admin ? "Admin " : "User";
                        Console.WriteLine(acc.GetUserName() + "\t " + status+ "\t"+service.name);
                        accounts++;
                    }
                }
            }

            if (accounts == 0)
                Console.WriteLine("No Accounts");
        }

        private void GetRequests(List<Service> services)
        {
            foreach (var service in services)
            {
                service.GetRequests();
            }
        }

        public override void Update(ConsoleKey key, List<Service> service)
        {
            switch (key)
            {
                case ConsoleKey.K:
                    GetRequests(service);
                    break;
                case ConsoleKey.I:
                    GetAccounts(service);
                    break;
                default: break;
            }
        }
    }
}