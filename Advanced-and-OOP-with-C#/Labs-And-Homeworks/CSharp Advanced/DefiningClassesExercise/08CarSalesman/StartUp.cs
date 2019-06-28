using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>(0);
            for (int i = 0; i < enginesCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);

                if (tokens.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (tokens.Length == 3)
                {
                    int displacement = 0;
                    bool isDisplacement = int.TryParse(tokens[2], out displacement);

                    if (isDisplacement)
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        string efficiency = tokens[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }
                }
                else if (tokens.Length == 4)
                {
                    int displacement = int.Parse(tokens[2]);
                    string efficiency = tokens[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
            }

            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                string engineModel = tokens[1];
                Engine engine = new Engine(null, 0);

                foreach (Engine eng in engines)
                {
                    if (eng.Model == engineModel)
                    {
                        engine = eng;
                    }
                }

                if (tokens.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (tokens.Length == 3)
                {
                    int weight = 0;
                    bool isWeight = int.TryParse(tokens[2], out weight);

                    if (isWeight)
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        string color = tokens[2];
                        cars.Add(new Car(model, engine, color));
                    }
                }
                else if (tokens.Length == 4)
                {
                    int weight = int.Parse(tokens[2]);
                    string color = tokens[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine("{0}:", car.Model);
                Console.WriteLine("  {0}:", car.engine.Model);
                Console.WriteLine("    Power: {0}", car.engine.Power);
                Console.WriteLine("    Displacement: {0}", car.engine.Displacement == 0 ? "n/a" : car.engine.Displacement.ToString());
                Console.WriteLine("    Efficiency: {0}", car.engine.Efficiency);
                Console.WriteLine("  Weight: {0}", car.Weight == 0 ? "n/a" : car.Weight.ToString());
                Console.WriteLine("  Color: {0}", car.Color);
            }
        }
    }
}
