using System;

namespace _03Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacityOfElevator = int.Parse(Console.ReadLine());

            double numberOfFullCourses = Math.Ceiling((double)numberOfPeople / capacityOfElevator);

            Console.WriteLine(numberOfFullCourses);
        }
    }
}
