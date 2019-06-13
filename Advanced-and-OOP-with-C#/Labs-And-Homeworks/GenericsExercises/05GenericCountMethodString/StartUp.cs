using System;

namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                double number = double.Parse(Console.ReadLine());
                box.Add(number);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Count(elementToCompare));
        }
    }
}
