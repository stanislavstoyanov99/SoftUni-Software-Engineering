using System;

namespace _01CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsNumber = int.Parse(Console.ReadLine());

            double priceOfFlourForPackage = double.Parse(Console.ReadLine());
            double priceOfEggForSingleEgg = double.Parse(Console.ReadLine());
            double priceofApronForSingleApron = double.Parse(Console.ReadLine());

            int freePackages = studentsNumber / 5;
            double apronPrice = priceofApronForSingleApron * Math.Ceiling(studentsNumber * 1.2);
            double eggsPrice = priceOfEggForSingleEgg * studentsNumber * 10;
            double flourPrice = priceOfFlourForPackage * (studentsNumber - freePackages);

            double priceForNeededItems = apronPrice + eggsPrice + flourPrice;

            Console.WriteLine(priceForNeededItems <= budget ? $"Items purchased for {priceForNeededItems:F2}$." 
                : $"{(priceForNeededItems - budget):F2}$ more needed.");
        }
    }
}
