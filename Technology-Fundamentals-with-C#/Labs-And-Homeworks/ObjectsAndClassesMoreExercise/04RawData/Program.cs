using System;
using System.Collections.Generic;
using System.Linq;

namespace _04RawData
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

                string carModel = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                Car currentCar = new Car(carModel, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(currentCar);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                var filteredFragileCars = cars.Where(c => c.CarsCargo.CargoType == "fragile" 
                && c.CarsCargo.CargoWeight < 1000).ToList();
                filteredFragileCars.ForEach(c => Console.WriteLine($"{c.Model}"));
            }
            else if (command == "flamable")
            {
                var filteredFlamableCars = cars.Where(c => c.CarsCargo.CargoType == "flamable" 
                && c.CarsEngine.EnginePower > 250).ToList();
                filteredFlamableCars.ForEach(c => Console.WriteLine($"{c.Model}"));
            }
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine CarsEngine { get; set; }
        public Cargo CarsCargo { get; set; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            Model = model;
            CarsEngine = new Engine(engineSpeed, enginePower);
            CarsCargo = new Cargo(cargoWeight, cargoType);
        }
    }

    class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }

        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }
    }

    class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }
    }
}
