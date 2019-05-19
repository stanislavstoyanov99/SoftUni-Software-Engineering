using System;
using System.Collections.Generic;

namespace _03SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string modelOfCar = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionPerKm = double.Parse(tokens[2]);

                Car currentCar = new Car(modelOfCar, fuelAmount, fuelConsumptionPerKm);
                cars.Add(currentCar);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" ");
                string carModel = commands[1];
                int amountOfKm = int.Parse(commands[2]);

                cars.Find(c => c.Model == carModel).Drive(amountOfKm);
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:F2} {c.TravelledDistance}"));
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKm { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public void Drive(int distance)
        {
            double fuelNeeded = distance * FuelConsumptionPerKm;

            if (FuelAmount >= fuelNeeded)
            {
                TravelledDistance += distance;
                FuelAmount -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
