using System;

class Program
{
    static void Main(string[] args)
    {
        double moneyForFood = double.Parse(Console.ReadLine());
        double moneyForSouvenirs = double.Parse(Console.ReadLine());
        double moneyForHotel = double.Parse(Console.ReadLine());

        double totalDistancePerOneDay = 420;
        double litersPerDay = (totalDistancePerOneDay / 100) * 7;
        double totalMoneyForFuel = litersPerDay * 1.85;
        double moneyForFoodAndSouvenirs = 3 * moneyForFood + 3 * moneyForSouvenirs;

        double discountForFirstDay = moneyForHotel * 0.90;
        double discountForSecondDay = moneyForHotel * 0.85;
        double discountForThirdDay = moneyForHotel * 0.80;

        double totalSum = totalMoneyForFuel + moneyForFoodAndSouvenirs + discountForFirstDay + discountForSecondDay + discountForThirdDay;
        Console.WriteLine($"Money needed: {totalSum:F2}");
    }
}
