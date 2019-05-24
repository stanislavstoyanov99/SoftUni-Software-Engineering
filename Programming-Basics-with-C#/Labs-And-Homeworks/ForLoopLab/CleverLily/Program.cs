using System;

class Program
{
    static void Main(string[] args)
    {
        int ageOfLili = int.Parse(Console.ReadLine());
        double priceOfWashingMachine = double.Parse(Console.ReadLine());
        int pricePerToy = int.Parse(Console.ReadLine());

        int toysCounter = 0;
        int moneyCounter = 0;

        double totalSumFromBirthdays = 0;
        double moneyFromBirthdays = 0;

        for (int daysCount = 1; daysCount <= ageOfLili; daysCount++)
        {
            if (daysCount % 2 == 0)
            {
                moneyFromBirthdays += 10;
                totalSumFromBirthdays += moneyFromBirthdays;
                moneyCounter++;
            }
            else
            {
                toysCounter++;
            }
        }
        double totalPriceForToys = pricePerToy * toysCounter;
        double leftMoney = (totalSumFromBirthdays + totalPriceForToys) - moneyCounter;
        if (leftMoney >= priceOfWashingMachine)
        {
            double restMoney = leftMoney - priceOfWashingMachine;
            Console.WriteLine($"Yes! {restMoney:F2}");
        }
        else
        {
            double neededMoney = priceOfWashingMachine - leftMoney;
            Console.WriteLine($"No! {neededMoney:F2}");
        }
    }
}
