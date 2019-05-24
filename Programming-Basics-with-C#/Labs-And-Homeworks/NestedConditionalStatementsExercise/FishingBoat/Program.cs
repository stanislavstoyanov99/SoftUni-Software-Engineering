using System;

class Program
{
    static void Main(string[] args)
    {
        int budget = int.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        int numberOfFisherman = int.Parse(Console.ReadLine());

        double price = default(double);
        double discountSum = default(double);
        double secondDiscount = default(double);
        double finalSum = default(double);
        double leftMoney = default(double);
        double neededMoney = default(double);

        switch (season)
        {
            case "Spring":
                if (numberOfFisherman <= 6)
                {
                    price = 3000;
                    discountSum = price * 0.10;
                    finalSum = price - discountSum;
                }
                else if (numberOfFisherman >= 7 && numberOfFisherman <= 11)
                {
                    price = 3000;
                    discountSum = price * 0.15;
                    finalSum = price - discountSum;
                }
                else if (numberOfFisherman >= 12)
                {
                    price = 3000;
                    discountSum = price * 0.25;
                    finalSum = price - discountSum;
                }
                if (numberOfFisherman % 2 == 0)
                {
                    secondDiscount = finalSum * 0.05;
                    finalSum = finalSum - secondDiscount;
                }
                else
                {
                    finalSum = price - discountSum;
                }
                break;
            case "Summer":
                if (numberOfFisherman <= 6)
                {
                    price = 4200;
                    discountSum = price * 0.10;
                    finalSum = price - discountSum;
                }
                else if (numberOfFisherman >= 7 && numberOfFisherman <= 11)
                {
                    price = 4200;
                    discountSum = price * 0.15;
                    finalSum = price - discountSum;
                }
                else if (numberOfFisherman >= 12)
                {
                    price = 4200;
                    discountSum = price * 0.25;
                    finalSum = price - discountSum;
                }
                if (numberOfFisherman % 2 == 0)
                {
                    secondDiscount = finalSum * 0.05;
                    finalSum = finalSum - secondDiscount;
                }
                else
                {
                    finalSum = price - discountSum;
                }
                break;
            case "Autumn":
                if (numberOfFisherman <= 6)
                {
                    price = 4200;
                    discountSum = price * 0.10;
                    finalSum = price - discountSum;
                }
                else if (numberOfFisherman >= 7 && numberOfFisherman <= 11)
                {
                    price = 4200;
                    discountSum = price * 0.10;
                    finalSum = price - discountSum;
                }
                else
                {
                    price = 4200;
                    discountSum = price * 0.25;
                    finalSum = price - discountSum;
                }
                break;
            case "Winter":
                if (numberOfFisherman <= 6)
                {
                    price = 2600;
                    discountSum = price * 0.10;
                    finalSum = price - discountSum;
                }
                else if (numberOfFisherman >= 7 && numberOfFisherman <= 11)
                {
                    price = 2600;
                    discountSum = price * 0.15;
                    finalSum = price - discountSum;
                }
                else if (numberOfFisherman >= 12)
                {
                    price = 2600;
                    discountSum = price * 0.25;
                    finalSum = price - discountSum;

                }
                if (numberOfFisherman % 2 == 0)
                {
                    secondDiscount = finalSum * 0.05;
                    finalSum = finalSum - secondDiscount;
                }
                else
                {
                    finalSum = price - discountSum;
                }
                break;
        }

        if (budget >= finalSum)
        {
            leftMoney = budget - finalSum;
            Console.WriteLine($"Yes! You have {leftMoney:F2} leva left.");
        }
        else
        {
            neededMoney = finalSum - budget;
            Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
        }
    }
}
