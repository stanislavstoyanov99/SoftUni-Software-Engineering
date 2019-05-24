using System;

class Program
{
    static void Main(string[] args)
    {
        string destination = Console.ReadLine();

        double totalMoney = 0;
        while (destination != "End")
        {
            double budget = double.Parse(Console.ReadLine());
            if (budget == 0)
            {
                Console.WriteLine($"Going to {destination}!");
            }
            else
            {
                while (true)
                {
                    double savedMoned = double.Parse(Console.ReadLine());
                    totalMoney += savedMoned;
                    if (totalMoney >= budget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
                totalMoney = 0;
                destination = Console.ReadLine();
            }
        }
    }
}
