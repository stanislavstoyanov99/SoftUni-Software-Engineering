using System;
using System.Collections.Generic;

using _01Vehicles.Models;

namespace _01Vehicles.Core
{
    public class Engine
    {
        private readonly List<Vehicle> vehicles;

        public Engine()
        {
            this.vehicles = new List<Vehicle>();
        }

        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = CreateCar(carInfo);
            this.vehicles.Add(car);

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = CreateTruck(truckInfo);
            this.vehicles.Add(truck);

            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = CreateBus(busInfo);
            this.vehicles.Add(bus);

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandsInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string typeOfCommand = commandsInfo[0];
                string typeOfVehicle = commandsInfo[1];

                if (typeOfCommand == "Drive")
                {
                    double distance = double.Parse(commandsInfo[2]);

                    DriveVehicle(car, truck, bus, typeOfVehicle, distance);
                }
                else if (typeOfCommand == "Refuel")
                {
                    double liters = double.Parse(commandsInfo[2]);

                    RefuelVehicle(car, truck, bus, typeOfVehicle, liters);
                }
                else if (typeOfCommand == "DriveEmpty")
                {
                    double distance = double.Parse(commandsInfo[2]);

                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }

            PrintVehicles();
        }


        private void PrintVehicles()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this.vehicles));
        }

        private void RefuelVehicle(Car car, Truck truck, Bus bus, string typeOfVehicle, double liters)
        {
            switch (typeOfVehicle)
            {
                case "Car":
                    car.Refuel(liters);
                    break;
                case "Truck":
                    truck.Refuel(liters);
                    break;
                case "Bus":
                    bus.Refuel(liters);
                    break;
            }
        }

        private void DriveVehicle(Car car, Truck truck, Bus bus, string typeOfVehicle, double distance)
        {
            switch (typeOfVehicle)
            {
                case "Car":
                    Console.WriteLine(car.Drive(distance));
                    break;
                case "Truck":
                    Console.WriteLine(truck.Drive(distance));
                    break;
                case "Bus":
                    Console.WriteLine(bus.Drive(distance));
                    break;
            }
        }

        private Car CreateCar(string[] carInfo)
        {
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            Car car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);

            return car;
        }

        private Bus CreateBus(string[] busInfo)
        {
            double carFuelQuantity = double.Parse(busInfo[1]);
            double carLitersPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Bus bus = new Bus(carFuelQuantity, carLitersPerKm, busTankCapacity);

            return bus;
        }

        private Truck CreateTruck(string[] truckInfo)
        {
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);

            return truck;
        }
    }
}
