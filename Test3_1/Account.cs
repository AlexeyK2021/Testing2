using System;
using System.Collections.Generic;

namespace Test3_1
{
    public class Account
    {
        private string UserName;
        private string Password;

        public Account(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public bool Check(string username, string password)
        {
            return username == UserName && password == Password;
        }

        public void ChangeUserName(string username)
        {
            UserName = username;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public string GetUserName()
        {
            return UserName;
        }

        public void SendRequest(string requestType,Service service)
        {
            service.ReceiveRequest(UserName,requestType);
        }
        
        public virtual void OutputControl()
        {
            Console.WriteLine("Press S to send Set request\nPress G to send Get request\n");
        }
        public virtual void Update(ConsoleKey key,List<Service> service)
        {
        }
    }
}