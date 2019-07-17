using System;
using System.Collections.Generic;
using _02WildFarm.Exceptions;
using _02WildFarm.Models.Animals;
using _02WildFarm.Models.Animals.Interfaces;
using _02WildFarm.Models.Food.Entities;
using _02WildFarm.Models.Food.Interfaces;

namespace _02WildFarm.Core
{
    public class Engine
    {
        private readonly List<IAnimal> animals;

        public Engine()
        {
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    IAnimal animal = GetAnimal(input);
                    Console.WriteLine(animal.AskForFood());

                    string[] foodInfo = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    IFood food = GetFood(foodInfo);

                    animal.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private IFood GetFood(string[] foodInfo)
        {
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            IFood food = null;
            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private IAnimal GetAnimal(string command)
        {
            string[] animalInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            IAnimal animal = null;

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                string livingRegion = animalInfo[3];

                if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalInfo[4];

                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                    else
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidAnimalTypeException);
                    }
                }
            }

            this.animals.Add(animal);

            return animal;
        }
    }
}
