using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                double firstTirePressure = double.Parse(tokens[5]);
                int firstTireAge = int.Parse(tokens[6]);
                double secondTirePressure = double.Parse(tokens[7]);
                int secondTireAge = int.Parse(tokens[8]);
                double thirdTirePressure = double.Parse(tokens[9]);
                int thirdTireAge = int.Parse(tokens[10]);
                double fourthTirePressure = double.Parse(tokens[11]);
                int fourthTireAge = int.Parse(tokens[12]);

                Tire firstTire = new Tire(firstTirePressure, firstTireAge);
                Tire secondTire = new Tire(secondTirePressure, secondTireAge);
                Tire thirdTire = new Tire(thirdTirePressure, thirdTireAge);
                Tire fourthTire = new Tire(fourthTirePressure, fourthTireAge);

                List<Tire> tires = new List<Tire>(4)
                {
                    firstTire,
                    secondTire,
                    thirdTire,
                    fourthTire
                };

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars
                .Where(c => c.cargo.cargoType == "fragile")
                .Where(c => c.tires.Any(t => t.tirePressure < 1))
                .Select(m => m.Model)
                .ToList()
                .ForEach(m => Console.WriteLine(m));
            }
            else if (command == "flamable")
            {
                cars
                .Where(c => c.cargo.cargoType == "flamable")
                .Where(e => e.engine.enginePower > 250)
                .Select(m => m.Model)
                .ToList()
                .ForEach(m => Console.WriteLine(m));
            }
        }
    }
}
