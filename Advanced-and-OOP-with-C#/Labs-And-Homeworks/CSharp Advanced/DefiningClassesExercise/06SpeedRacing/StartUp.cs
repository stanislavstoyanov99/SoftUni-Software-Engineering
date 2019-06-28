using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionFor1km = double.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = tokens[1];
                int amountOfKm = int.Parse(tokens[2]);

                Car car = cars.FirstOrDefault(x => x.Model == carModel);
                car.Drive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
