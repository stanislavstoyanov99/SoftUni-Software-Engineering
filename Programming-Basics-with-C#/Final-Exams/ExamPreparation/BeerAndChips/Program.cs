using System;

class Program
{
    static void Main(string[] args)
    {
        string fanName = Console.ReadLine();
        double budget = double.Parse(Console.ReadLine());
        int numberOfBottlesBeer = int.Parse(Console.ReadLine());
        int numberOfPackages = int.Parse(Console.ReadLine());

        double totalPriceOfBeer = 1.20 * numberOfBottlesBeer;
        double pricePerPackage = 0.45 * totalPriceOfBeer;
        double totalPriceOfChips = pricePerPackage * numberOfPackages;
        double totalSum = totalPriceOfBeer + Math.Ceiling(totalPriceOfChips);

        if (totalSum <= budget)
        {
            double leftMoney = budget - totalSum;
            Console.WriteLine($"{fanName} bought a snack and has {leftMoney:F2} leva left.");
        }
        else
        {
            double neededMoney = totalSum - budget;
            Console.WriteLine($"{fanName} needs {neededMoney:F2} more leva!");
        }
    }
}
