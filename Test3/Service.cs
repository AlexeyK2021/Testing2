using System;
using System.Collections.Generic;

namespace Test3
{
    public class Service
    {
        public Service()
        {
        }

        public static List<string> requests = new List<string>();
        public static List<Account> Accounts = new List<Account>();
        public Account AccountNow = null;

        public void ReceiveRequest(string username, string requestType)
        {
            AddToStats(username, requestType);
            Console.WriteLine($"Receiving a {requestType} request");
        }

        public void GetStats()
        {
            for (int i = 0; i < requests.Count; i += 2)
            {
                Console.WriteLine($"Username: {requests[i]}; Type of request: {requests[i + 1]}");
            }
        }

        private void AddToStats(string username, string requestType)
        {
            requests.Add(username);
            requests.Add(requestType);
        }
    }
}