using System;
using System.Collections.Generic;

namespace Test3_1
{
    class Program
    {
        private static List<Service> services = new List<Service>();
        private static bool isControl = true;
        private static Service ServiceNow = null;

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Now you should log in to the service and can log in to account by pressing L\n" +
                "If you want to create any one account just press D\nIf you want to create a new service press M\n" +
                "To see what you can do press W\n" +
                "To get help press H\n" +
                "To log out from account press Q\n" +
                "To log out from account press T");
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
                case ConsoleKey.M:
                    CreateService();
                    break;
                case ConsoleKey.L:
                    if (ServiceNow == null)
                        ServiceNow = LogInToService();
                    else
                        ServiceNow.AccountNow = LogIn();
                    break;
                case ConsoleKey.W:
                    if (ServiceNow.AccountNow != null)
                        ServiceNow.AccountNow.OutputControl();
                    else Console.WriteLine("Log in please");
                    break;
                case ConsoleKey.S:
                    if (ServiceNow.AccountNow != null)
                        SendRequest("set", ServiceNow);
                    else Console.WriteLine("Log in please");
                    break;
                case ConsoleKey.G:
                    if (ServiceNow.AccountNow != null)
                        SendRequest("get", ServiceNow);
                    else Console.WriteLine("Log in please");
                    break;
                case ConsoleKey.Q:
                    Quit();
                    break;
                case ConsoleKey.T:
                    QuitFromService();
                    break;
                case ConsoleKey.H:
                    Console.WriteLine(
                        "If you want to create any one account just press D\n To see the list of accounts press L\n " +
                        "To log in to your account press I\n To see what you can do press W\n To get help press H\n To log out press q");
                    break;
                default:
                    ServiceNow.AccountNow.Update(key, services);
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
            }
            else
            {
                Console.WriteLine("Enter the username");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the password");
                string passwd = Console.ReadLine();

                if (typeOfUser == ConsoleKey.A)
                {
                    ServiceNow.Accounts.Add(new Admin(name, passwd));
                }
                else
                {
                    ServiceNow.Accounts.Add(new Account(name, passwd));
                }
            }
        }

        private static void CreateService()
        {
            Console.WriteLine(
                "You can create service.\nTo continue press E");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.E)
            {
                Console.WriteLine("Now you should give a name to your service\n");
                String name = Console.ReadLine();
                services.Add(new Service(name));
                Console.WriteLine($"You created a service ({name})");
            }
            else
                Console.WriteLine("I don't know this key. Please press M");
        }

        private static Service LogInToService()
        {
            Console.WriteLine("Enter the name of service");
            string name = Console.ReadLine();
            for (int i = 0; i < services.Count; i++)
            {
                if (services[i].name == name)
                {
                    Console.WriteLine("You are logged successfully");
                    return services[i];
                }
            }

            Console.WriteLine("You logging in failed. Press L and try again");
            return null;
        }

        private static Account LogIn()
        {
            Console.WriteLine("Enter the username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();

            for (int i = 0; i < ServiceNow.Accounts.Count; i++)
            {
                if (ServiceNow.Accounts[i].Check(username, password))
                {
                    Console.WriteLine("You logged in successfully");
                    return ServiceNow.Accounts[i];
                }
            }

            Console.WriteLine("You logging in failed. Press L and try again");
            return null;
        }

        private static void SendRequest(string typeOfRequest, Service service)
        {
            if (ServiceNow.AccountNow != null)
            {
                ServiceNow.AccountNow.SendRequest(typeOfRequest, service);
            }
            else Console.WriteLine("Log in please");
        }

        private static void Quit()
        {
            if (ServiceNow.AccountNow != null)
            {
                Console.WriteLine("You logged out successfully");
                ServiceNow.AccountNow = null;
            }
            else Console.WriteLine("Log in please");
        }

        private static void QuitFromService()
        {
            if (ServiceNow != null)
            {
                Console.WriteLine("You logged out successfully");
                ServiceNow = null;
            }
            else Console.WriteLine("Log in please");
        }
    }
}