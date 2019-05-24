using System;

class Program
{
    static void Main(string[] args)
    {
        int quota = int.Parse(Console.ReadLine());

        double profit = 0;
        double expenses = 0;
        int fishCounter = 0;

        for (int i = 1; i <= quota; i++)
        {
            string input = Console.ReadLine();
            if (input == "Stop")
            {
                break;
            }
            double fishKg = double.Parse(Console.ReadLine());
            if (i % 3 == 0)
            {
                double currentProfit = 0;
                for (int counter = 0; counter < input.Length; counter++)
                {
                    char symbol = input[counter];
                    currentProfit += symbol;
                }
                profit += currentProfit / fishKg;
            }
            else
            {
                double currentExpenses = 0;
                for (int counter = 0; counter < input.Length; counter++)
                {
                    char symbol = input[counter];
                    currentExpenses += symbol;
                }
                expenses += currentExpenses / fishKg;
            }

            if (i == quota)
            {
                Console.WriteLine("Lyubo fulfilled the quota!");
            }
            fishCounter++;
        }
        if (profit > expenses)
        {
            double leftMoney = profit - expenses;
            Console.WriteLine($"Lyubo's profit from {fishCounter} fishes is {leftMoney:F2} leva.");
        }
        else
        {
            double leftMoney = expenses - profit;
            Console.WriteLine($"Lyubo lost {leftMoney:F2} leva today.");
        }
    }
}
