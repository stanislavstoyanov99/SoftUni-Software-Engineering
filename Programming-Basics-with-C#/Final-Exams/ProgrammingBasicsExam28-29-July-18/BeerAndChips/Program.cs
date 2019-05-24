using System;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string personName = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine()); //5
            int beerBottles = int.Parse(Console.ReadLine()); //2
            int chipsPackage = int.Parse(Console.ReadLine()); //4

            double totalbeerPrice = 1.20 * beerBottles; //2.4
            double chipsPrice = 0.45 * totalbeerPrice; //1.08
            double totalChipsPrice = Math.Ceiling(chipsPrice * chipsPackage); //5
            double totalSum = totalbeerPrice + totalChipsPrice; // 7.4
            if (totalSum <= budget)
            {
                double restMoney = Math.Abs(budget - totalSum);
                Console.WriteLine($"{personName} bought a snack and has {restMoney:F2} leva left.");
            }
            else
            {
                double neededMoney = Math.Abs(totalSum - budget);
                Console.WriteLine($"{personName} needs {neededMoney:F2} more leva!");
            }
        }
    }
}
