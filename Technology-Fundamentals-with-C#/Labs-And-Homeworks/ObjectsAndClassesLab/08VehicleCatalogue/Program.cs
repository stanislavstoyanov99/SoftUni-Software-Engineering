using System;
using System.Collections.Generic;
using System.Linq;

namespace _08VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new CatalogVehicle();   // create new object from the class CatalogVehicle

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split("/");
                string vehicleType = tokens[0];
                string vehicleBrand = tokens[1];
                string vehicleModel = tokens[2];

                if (vehicleType == "Car")
                {
                    int horsePower = int.Parse(tokens[3]);
                    vehicles.Cars.Add(new Car(vehicleBrand, vehicleModel, horsePower)); // add new object Car to the list Cars from the class Catalog
                }
                else
                {
                    int weight = int.Parse(tokens[3]);
                    vehicles.Trucks.Add(new Truck(vehicleBrand, vehicleModel, weight)); // add new object Truck to the list Trucks from the class Catalog
                }
            }

            Console.WriteLine("Cars:");
            var filteredCars = vehicles.Cars.OrderBy(c => c.Brand).ToList(); // create new list filteredCars that holds the brand ordered alphabetically

            filteredCars.ForEach(c => Console.WriteLine($"{c.Brand}: {c.Model} - {c.HorsePower}hp"));
            /*Another way
            foreach (var car in filteredCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
            */

            Console.WriteLine("Trucks:");
            var filteredTrucks = vehicles.Trucks.OrderBy(t => t.Brand).ToList();

            filteredTrucks.ForEach(t => Console.WriteLine($"{t.Brand}: {t.Model} - {t.Weight}kg"));
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
    }

    class CatalogVehicle
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public CatalogVehicle() // constructor that holds the Cars and Trucks properties and creates lists
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}
