using System;
using System.Collections.Generic;
using System.Linq;

namespace _06VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ");
                string vehicleType = tokens[0];
                string vehicleModel = tokens[1];
                string vehicleColor = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                Vehicle currentVehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, horsePower);
                catalogue.Add(currentVehicle);
            }

            string model = string.Empty;
            while ((model = Console.ReadLine()) != "Close the Catalogue")
            {
                Console.WriteLine(catalogue.Find(x => x.Model == model)); // find only the vehicles with the received model
            }

            var cars = catalogue.Where(x => x.Type == "car").ToList(); // filter the catalogue list and make new list cars
            var trucks = catalogue.Where(x => x.Type == "truck").ToList(); // filter the catalogue list and make new list trucks

            double totalCarsHorsePower = default(double);
            double totalTrucksHorsePower = default(double);

            // use extension method ForEach instead of foreach loop to sum the horse power of cars and trucks
            cars.ForEach(c => totalCarsHorsePower += c.HorsePower);
            trucks.ForEach(t => totalTrucksHorsePower += t.HorsePower);

            double averageCarsHorsePower = totalCarsHorsePower / cars.Count;
            double averageTrucksHorsePower = totalTrucksHorsePower / trucks.Count;

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public override string ToString()
        {
            // filter the type of vehicle and print information about it on new lines
            return $"Type: {(Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                $"Model: {Model}{Environment.NewLine}" +
                                $"Color: {Color}{Environment.NewLine}" +
                                $"Horsepower: {HorsePower}";
        }
    }
}
