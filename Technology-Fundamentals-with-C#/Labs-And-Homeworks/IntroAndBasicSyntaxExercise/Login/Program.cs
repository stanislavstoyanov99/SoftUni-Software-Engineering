using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string reversedUsername = string.Empty;
            int counter = 0;

            for (int i = userName.Length; i > 0; i--)
            {
                reversedUsername += userName[i - 1];
            }

            while (true)
            {
                string password = Console.ReadLine();

                if (password == reversedUsername)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else
                {
                    counter++;
                    if (counter >= 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
