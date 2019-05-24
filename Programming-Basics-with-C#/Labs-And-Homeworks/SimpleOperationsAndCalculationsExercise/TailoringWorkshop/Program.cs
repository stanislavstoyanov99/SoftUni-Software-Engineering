using System;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTables = int.Parse(Console.ReadLine());
            double lengthOfTables = double.Parse(Console.ReadLine());
            double widthOfTables = double.Parse(Console.ReadLine());

            double totalAreaOfCovers = numberOfTables * (lengthOfTables + 0.6) * (widthOfTables + 0.6);
            double totalAreaOfSquares = numberOfTables * (lengthOfTables / 2) * (lengthOfTables / 2);
            double sumInDollars = (totalAreaOfCovers * 7) + (totalAreaOfSquares * 9);
            double sumInLevas = sumInDollars * 1.85;
            Console.WriteLine("{0:F2} USD", sumInDollars);
            Console.WriteLine("{0:F2} BGN", sumInLevas);
        }
    }
}
