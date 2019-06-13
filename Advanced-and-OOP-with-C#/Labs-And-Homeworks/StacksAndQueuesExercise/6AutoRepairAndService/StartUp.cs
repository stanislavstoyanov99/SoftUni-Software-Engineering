namespace _6AutoRepairAndService
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carModels = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queueOfCars = new Queue<string>(carModels);
            Stack<string> servedCars = new Stack<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Service" && queueOfCars.Count > 0)
                {
                    string currentCar = queueOfCars.Dequeue();
                    servedCars.Push(currentCar);
                    Console.WriteLine($"Vehicle {currentCar} got served.");
                }
                else if (input.Contains("CarInfo"))
                {
                    string carName = input.Split('-')[1];

                    if (queueOfCars.Contains(carName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (input == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }
            }

            if (queueOfCars.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", queueOfCars)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
        }
    }
}
