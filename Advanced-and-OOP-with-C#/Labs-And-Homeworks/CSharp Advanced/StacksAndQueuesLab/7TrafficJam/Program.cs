using System;
using System.Collections.Generic;

namespace _7TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int countOfCars = int.Parse(Console.ReadLine());

            int numberOfCars = 0;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    int currentCount = 0;

                    if (queue.Count > countOfCars)
                    {
                        currentCount = countOfCars;
                    }
                    else
                    {
                        currentCount = queue.Count;
                    }

                    for (int i = 0; i < currentCount; i++)
                    {
                        string passedCar = queue.Dequeue();
                        Console.WriteLine($"{passedCar} passed!");
                        numberOfCars++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{numberOfCars} cars passed the crossroads.");
        }
    }
}
