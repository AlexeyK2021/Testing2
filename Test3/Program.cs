using System;

namespace Test3
{
    class Program
    {
        private static Service service = null;
        private static bool isControl = true;

        static void Main(string[] args)
        {
            service = new Service();
            CreateAccount();
            Console.WriteLine(
                "Now you should log in by pressing L\n" +
                "If you want to create any one account just press D\n" +
                "\nTo see what you can do press W\n" +
                "To get help press H\nTo log out press q");
            while (isControl)
            {
                DoAction(Console.ReadKey(true).Key);
            }
        }

        private static void DoAction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D:
                    CreateAccount();
                    break;
                case ConsoleKey.L:
                    service.AccountNow = LogIn();
                    break;
                case ConsoleKey.W:
                    if (service.AccountNow != null)
                        service.AccountNow.OutputControl();
                    else Console.WriteLine("Log in please");
                    break;
                case ConsoleKey.S:
                    if (service.AccountNow != null)
                        SendRequest("set");
                    else Console.WriteLine("Log in please");
                    break;
                case ConsoleKey.G:
                    if (service.AccountNow != null)
                        SendRequest("get");
                    else Console.WriteLine("Log in please");
                    break;
                case ConsoleKey.Q:
                    Quit();
                    break;
                case ConsoleKey.H:
                    Console.WriteLine(
                        "If you want to create any one account just press D\n To see the list of accounts press L\n " +
                        "To log in to your account press I\n To see what you can do press W\n To get help press H\n To log out press q");
                    break;
                default:
                    service.AccountNow.Update(key);
                    break;
            }
        }

        private static void CreateAccount()
        {
            Console.WriteLine(
                "You can create an admin or user account.\nPress U to create user account\nPress A to create an admin account");
            ConsoleKey typeOfUser = Console.ReadKey(true).Key;
            if (typeOfUser != ConsoleKey.A && typeOfUser != ConsoleKey.U)
            {
                Console.WriteLine("I don't know this letter. Press D and try again");
                return;
            }
            else
            {
                Console.WriteLine("Enter the username");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the password");
                string passwd = Console.ReadLine();

                if (typeOfUser == ConsoleKey.A)
                {
                    Service.Accounts.Add(new Admin(name, passwd));
                }
                else
                {
                    Service.Accounts.Add(new Account(name, passwd));
                }
            }
        }

        private static Account LogIn()
        {
            Console.WriteLine("Enter the username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();

            for (int i = 0; i < Service.Accounts.Count; i++)
            {
                if (Service.Accounts[i].Check(username, password))
                {
                    Console.WriteLine("You logged in successfully");
                    return Service.Accounts[i];
                }
            }

            Console.WriteLine("You logging in failed. Press L and try again");
            return null;
        }

        private static void SendRequest(string typeOfRequest)
        {
            if (service.AccountNow != null)
            {
                service.AccountNow.SendRequest(typeOfRequest);
            }
            else Console.WriteLine("Log in please");
        }

        private static void Quit()
        {
            if (service.AccountNow != null)
            {
                Console.WriteLine("You logged out successfully");
                service.AccountNow = null;
            }
            else Console.WriteLine("Log in please");
        }
    }
}