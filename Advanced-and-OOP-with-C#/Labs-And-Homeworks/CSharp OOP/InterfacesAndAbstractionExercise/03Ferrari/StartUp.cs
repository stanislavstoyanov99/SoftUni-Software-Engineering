using System;

namespace _03Ferrari
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            ICar car = new Ferrari(driverName);
            Console.WriteLine(car);
        }
    }
}
