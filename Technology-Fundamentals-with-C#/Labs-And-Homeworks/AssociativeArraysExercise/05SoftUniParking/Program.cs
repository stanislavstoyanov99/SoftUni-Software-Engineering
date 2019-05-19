using System;
using System.Collections.Generic;

namespace _05SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            var registeredUsers = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                string userName = tokens[1];

                if (command == "register")
                {
                    string licensePlateNumber = tokens[2];
                    if (!registeredUsers.ContainsKey(userName))
                    {
                        registeredUsers.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        // if a user tries to register another license plate, using the same username
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else if (command == "unregister")
                {
                    if (!registeredUsers.ContainsKey(userName))
                    {
                        // If the user is not present in the database
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        registeredUsers.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                }
            }

            foreach (var user in registeredUsers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
