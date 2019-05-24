using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFigure = Console.ReadLine();
            double area = 0.0;
            double sizeA = 0.0;
            double sizeB = 0.0;
            double radius = 0.0;
            double heightOfSizeA = 0.0;

            if (typeOfFigure == "square")
            {
                sizeA = double.Parse(Console.ReadLine());
                area = sizeA * sizeA;
            }
            else if (typeOfFigure == "rectangle")
            {
                sizeA = double.Parse(Console.ReadLine());
                sizeB = double.Parse(Console.ReadLine());
                area = sizeA * sizeB;
            }
            else if (typeOfFigure == "circle")
            {
                radius = double.Parse(Console.ReadLine());
                area = Math.PI * Math.Pow(radius , 2);
            }
            else if (typeOfFigure == "triangle")
            {
                sizeA = double.Parse(Console.ReadLine());
                heightOfSizeA = double.Parse(Console.ReadLine());
                area = (sizeA * heightOfSizeA) / 2;
            }
            Console.WriteLine($"{Math.Round(area, 3)}");
        }
    }
}
