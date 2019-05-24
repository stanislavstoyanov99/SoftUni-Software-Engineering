using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfExcursion = double.Parse(Console.ReadLine());
            int numberOfPuzzles = int.Parse(Console.ReadLine());
            int numberOfTalkingDolls = int.Parse(Console.ReadLine());
            int numberOfBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double talkingDollPrice = 3.00;
            double bearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2.00;
            double discount = 0;

            double totalPuzzlesPrice = puzzlePrice * numberOfPuzzles;
            double totalTalkingDollsPrice = talkingDollPrice * numberOfTalkingDolls;
            double totalBearPrice = bearPrice * numberOfBears;
            double totalMinionPrice = minionPrice * numberOfMinions;
            double totalTruckPrice = truckPrice * numberOfTrucks;
            double sum = totalPuzzlesPrice + totalTalkingDollsPrice + totalBearPrice + totalMinionPrice + totalTruckPrice;
            double numberOfToys = numberOfPuzzles + numberOfTalkingDolls + numberOfBears + numberOfMinions + numberOfTrucks;

            if (numberOfToys >= 50)
            {
                discount = 0.25 * sum;
            }
            double totalSum = sum - discount;
            double rent = 0.10 * totalSum;
            double profit = totalSum - rent;
            double restMoney = Math.Abs(profit - priceOfExcursion);
            if (profit >= priceOfExcursion)
            {
                Console.WriteLine($"Yes! {restMoney:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {restMoney:F2} lv needed.");
            }
        }
    }
}
