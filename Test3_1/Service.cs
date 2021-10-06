using System;
using System.Collections.Generic;

namespace Test3_1
{
    public class Service
    {
        private List<string> requests = new List<string>();
        public List<Account> Accounts = new List<Account>();
        public  Account AccountNow = null;
        public String name;
        
        public Service(String name)
        {
            this.name = name;
        }
        
        public void ReceiveRequest(string username, string requestType)
        {
            AddToStats(username, requestType);
            Console.WriteLine($"Service received a {requestType} request");
        }

        public void GetRequests()
        {
            for (int i = 0; i < requests.Count; i += 2)
            {
                Console.WriteLine($"Request %{requests[i + 1]}% from user {requests[i]}");
            }
        }

        private void AddToStats(string username, string requestType)
        {
            requests.Add(username);
            requests.Add(requestType);
        }
    }
}