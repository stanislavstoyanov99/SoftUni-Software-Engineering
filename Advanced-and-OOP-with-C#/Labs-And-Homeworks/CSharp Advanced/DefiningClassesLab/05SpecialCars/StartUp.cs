using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            List<Tire[]> tires = new List<Tire[]>();

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] currentSet = new Tire[4]
                {
                    new Tire(int.Parse(tireInfo[0]), double.Parse(tireInfo[1])),
                    new Tire(int.Parse(tireInfo[2]), double.Parse(tireInfo[3])),
                    new Tire(int.Parse(tireInfo[4]), double.Parse(tireInfo[5])),
                    new Tire(int.Parse(tireInfo[6]), double.Parse(tireInfo[7])),
                };

                tires.Add(currentSet);
            }

            string secondInput = string.Empty;
            List<Engine> engines = new List<Engine>();

            while ((secondInput = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = secondInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            string thirdInput = string.Empty;
            List<Car> cars = new List<Car>();

            while ((thirdInput = Console.ReadLine()) != "Show special")
            {
                string[] carsInfo = thirdInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carMake = carsInfo[0];
                string carModel = carsInfo[1];
                int carYear = int.Parse(carsInfo[2]);
                double carFuelQuantity = double.Parse(carsInfo[3]);
                double carFuelConsumption = double.Parse(carsInfo[4]);
                int engineIndex = int.Parse(carsInfo[5]);
                int tiresIndex = int.Parse(carsInfo[6]);

                Car car = new Car(carMake, carModel, carYear, carFuelQuantity, carFuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            var specialCars = cars
                .Where(x => x.Year >= 2017
                && x.Engine.HorsePower > 330
                && x.Tire.Select(y => y.Pressure).Sum() >= 9
                && x.Tire.Select(y => y.Pressure).Sum() <= 10)
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car);
            }
        }
    }
}
