using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class Runner
    {
        private List<Car> cars;

        public Runner()
        {
            this.cars = new List<Car>();
        }

        public void Start()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = this.CreateCar(parameters);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            FilterCars(command);
        }

        private void FilterCars(string command)
        {
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintCar(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                PrintCar(flamable);
            }
        }

        private void PrintCar(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private Car CreateCar(string[] parameters)
        {
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            int firstTireAge = int.Parse(parameters[6]);
            double firstTirePressure = double.Parse(parameters[5]);
            Tire firstTire = new Tire(firstTireAge, firstTirePressure);

            int secondTireAge = int.Parse(parameters[8]);
            double secondTirePressure = double.Parse(parameters[7]);
            Tire secondTire = new Tire(secondTireAge, secondTirePressure);

            int thirdTireAge = int.Parse(parameters[10]);
            double thirdTirePressure = double.Parse(parameters[9]);
            Tire thirdTire = new Tire(thirdTireAge, thirdTirePressure);

            double fourthTirePressure = double.Parse(parameters[11]);
            int fourthTireAge = int.Parse(parameters[12]);
            Tire fourthTire = new Tire(fourthTireAge, fourthTirePressure);

            Car car = new Car(model, engine, cargo, firstTire, secondTire, thirdTire, fourthTire);

            return car;
        }
    }
}
