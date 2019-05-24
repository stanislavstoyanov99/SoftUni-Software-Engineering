using System;

class Program
{
    static void Main(string[] args)
    {
        double distanceInKm = double.Parse(Console.ReadLine());
        double consumptionOfFuel = double.Parse(Console.ReadLine());
        double priceOfFuelPerLiter = double.Parse(Console.ReadLine());
        double earnedMoney = double.Parse(Console.ReadLine());

        double consumptionOfCar = (distanceInKm * consumptionOfFuel) / 100;
        double totalConsumption = consumptionOfCar * priceOfFuelPerLiter;
        double difference = Math.Abs(totalConsumption - earnedMoney);

        if (earnedMoney >= totalConsumption)
        {
            Console.WriteLine($"You can go home. {difference:F2} money left.");
        }
        else
        {
            double restMoney = earnedMoney / 5;
            Console.WriteLine($"Sorry, you cannot go home. Each will receive {restMoney:F2} money.");
        }
    }
}
