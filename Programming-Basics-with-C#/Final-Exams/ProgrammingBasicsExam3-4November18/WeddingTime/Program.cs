using System;

class Program
{
    static void Main(string[] args)
    {
        double whiskeyPrice = double.Parse(Console.ReadLine());
        double waterQuantity = double.Parse(Console.ReadLine());
        double wineQuantity = double.Parse(Console.ReadLine());
        double champagneQuantity = double.Parse(Console.ReadLine());
        double whiskeyQuantity = double.Parse(Console.ReadLine());

        double champagnePricePerLiter = whiskeyPrice * 0.5;
        double winePricePerLiter = champagnePricePerLiter * 0.4;
        double waterPricePerLiter = champagnePricePerLiter * 0.1;

        double sumForChampagne = champagneQuantity * champagnePricePerLiter;
        double sumForWine = wineQuantity * winePricePerLiter;
        double sumForWater = waterQuantity * waterPricePerLiter;
        double sumForWhiskey = whiskeyQuantity * whiskeyPrice;

        double totalSum = sumForChampagne + sumForWine + sumForWater + sumForWhiskey;
        Console.WriteLine($"{totalSum:F2}");
    }
}
