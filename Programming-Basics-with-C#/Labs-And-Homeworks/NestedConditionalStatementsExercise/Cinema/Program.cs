using System;

class Program
{
    static void Main(string[] args)
    {
        string projection = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        double price = default(double);

        if (projection == "Premiere")
        {
            price = 12.00;
        }
        else if (projection == "Normal")
        {
            price = 7.50;
        }
        else if (projection == "Discount")
        {
            price = 5.00;
        }
        double areaOfHall = rows * cols;
        double totalIncome = areaOfHall * price;
        Console.WriteLine($"{totalIncome:F2} leva");
    }
}
