using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            var lengthOfHall = double.Parse(Console.ReadLine());
            var widthOfHall = double.Parse(Console.ReadLine());
            var sideOfWardrobe = double.Parse(Console.ReadLine());

            double sizeOfHallInCentimetres = (lengthOfHall * 100) * (widthOfHall * 100);
            double sizeOfWardrobe = (sideOfWardrobe * 100) * (sideOfWardrobe * 100);
            double sizeOfBench = sizeOfHallInCentimetres / 10;
            double freeSpace = (sizeOfHallInCentimetres - sizeOfWardrobe) - sizeOfBench;
            double numberOfDancers = freeSpace / 7_040;
            Console.WriteLine(Math.Floor(numberOfDancers));
        }
    }
}
