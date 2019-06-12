using System;
using System.Collections.Generic;

namespace _01UniqueUsernames
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            int numberOfUsernames = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            string username = string.Empty;
            for (int i = 0; i < numberOfUsernames; i++)
            {
                username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
