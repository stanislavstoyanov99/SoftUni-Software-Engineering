using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceOfWhiskey = double.Parse(Console.ReadLine());
            double capacityOfBeer = double.Parse(Console.ReadLine());
            double capacityOfWine = double.Parse(Console.ReadLine());
            double capacityOfRakia = double.Parse(Console.ReadLine());
            double capacityOfWhiskey = double.Parse(Console.ReadLine());

            var priceOfRakiaPerLiter = priceOfWhiskey / 2;
            var priceOfWinePerLiter = priceOfRakiaPerLiter - (0.4 * priceOfRakiaPerLiter);
            var priceOfBeerPerLiter = priceOfRakiaPerLiter - (0.8 * priceOfRakiaPerLiter);

            var sumOfRakia = capacityOfRakia * priceOfRakiaPerLiter;
            var sumOfWine = capacityOfWine * priceOfWinePerLiter;
            var sumOfBeer = priceOfBeerPerLiter * capacityOfBeer;
            var sumOfWhiskey = priceOfWhiskey * capacityOfWhiskey;

            var totalSum = sumOfRakia + sumOfWine + sumOfBeer + sumOfWhiskey;
            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
