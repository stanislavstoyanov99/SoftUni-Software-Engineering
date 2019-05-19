using System;

namespace _03GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            double priceOfGame = default(double);
            double totalSpent = default(double);

            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        priceOfGame = 39.99;
                        break;
                    case "CS: OG":
                        priceOfGame = 15.99;
                        break;
                    case "Zplinter Zell":
                        priceOfGame = 19.99;
                        break;
                    case "Honored 2":
                        priceOfGame = 59.99;
                        break;
                    case "RoverWatch":
                        priceOfGame = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        priceOfGame = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (priceOfGame > balance)
                {
                    Console.WriteLine("Too Expensive");
                }

                if ((balance >= priceOfGame) && priceOfGame > 0)
                {
                    Console.WriteLine($"Bought {input}");
                    balance -= priceOfGame;
                    totalSpent += priceOfGame;
                }

                if (balance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${balance:F2}");
        }
    }
}
