using System;

class Program
{
    static void Main(string[] args)
    {
        string typeOfFlowers = Console.ReadLine();
        int numberOfFlowers = int.Parse(Console.ReadLine());
        int budget = int.Parse(Console.ReadLine());

        double priceOfRoses = 5.00;
        double priceOfDalia = 3.80;
        double priceOfLale = 2.80;
        double priceOfNarcis = 3.00;
        double priceOfGladiola = 2.50;

        double sumForFlowers = default(double);
        double leftMoney = default(double);
        double neededMoney = default(double);
        double discountSum = default(double);

        if (typeOfFlowers == "Roses")
        {
            sumForFlowers = numberOfFlowers * priceOfRoses;
            if (numberOfFlowers > 80)
            {
                discountSum = 0.10 * sumForFlowers;
                sumForFlowers = sumForFlowers - discountSum;
            }
        }
        else if (typeOfFlowers == "Dahlias")
        {
            sumForFlowers = numberOfFlowers * priceOfDalia;
            if (numberOfFlowers > 90)
            {
                discountSum = 0.15 * sumForFlowers;
                sumForFlowers = sumForFlowers - discountSum;
            }
        }
        else if (typeOfFlowers == "Tulips")
        {
            sumForFlowers = numberOfFlowers * priceOfLale;
            if (numberOfFlowers > 80)
            {
                discountSum = 0.15 * sumForFlowers;
                sumForFlowers = sumForFlowers - discountSum;
            }
        }
        else if (typeOfFlowers == "Narcissus")
        {
            sumForFlowers = numberOfFlowers * priceOfNarcis;
            if (numberOfFlowers < 120)
            {
                discountSum = 0.15 * sumForFlowers;
                sumForFlowers = sumForFlowers + discountSum;
            }
        }
        else if (typeOfFlowers == "Gladiolus")
        {
            sumForFlowers = numberOfFlowers * priceOfGladiola;
            if (numberOfFlowers < 80)
            {
                discountSum = 0.20 * sumForFlowers;
                sumForFlowers = sumForFlowers + discountSum;
            }
        }

        if (sumForFlowers > budget)
        {
            neededMoney = sumForFlowers - budget;
            Console.WriteLine($"Not enough money, you need {neededMoney:F2} leva more.");
        }
        else
        {
            leftMoney = budget - sumForFlowers;
            Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlowers} and {leftMoney:F2} leva left.");
        }
    }
}

