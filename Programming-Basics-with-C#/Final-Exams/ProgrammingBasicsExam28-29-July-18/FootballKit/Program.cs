using System;

namespace FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double sum = double.Parse(Console.ReadLine());

            double shortsPrice = tshirtPrice * 0.75;
            double socksPrice = shortsPrice * 0.2;
            double shoesPrice = 2 * (shortsPrice + tshirtPrice);
            double currentSum = tshirtPrice + shortsPrice + socksPrice + shoesPrice;
            double discount = 0.15 * currentSum;
            double totalSum = Math.Abs(currentSum - discount);
            if (totalSum >= sum)
            {
                Console.WriteLine($"Yes, he will earn the world-cup replica ball! \nHis sum is {totalSum:F2} lv.");
            }
            else
            {
                double neededMoney = Math.Abs(sum - totalSum);
                Console.WriteLine($"No, he will not earn the world-cup replica ball.\nHe needs {neededMoney:F2} lv. more.");
            }
        }
    }
}
