using System;

class Program
{
    static void Main(string[] args)
    {
        int computerNumber = int.Parse(Console.ReadLine());

        double totalSales = 0;
        double averageRating = 0;

        for (int i = 1; i <= computerNumber; i++)
        {
            int number = int.Parse(Console.ReadLine());

            double rating = number % 10;
            double sales = number / 10;

            averageRating += rating / computerNumber;

            switch (rating)
            {
                case 2: break;
                case 3: totalSales += 0.5 * sales; break;
                case 4: totalSales += 0.7 * sales; break;
                case 5: totalSales += 0.85 * sales; break;
                case 6: totalSales += sales; break;
            }
        }
        Console.WriteLine($"{totalSales:F2}");
        Console.WriteLine($"{averageRating:F2}");
    }
}
