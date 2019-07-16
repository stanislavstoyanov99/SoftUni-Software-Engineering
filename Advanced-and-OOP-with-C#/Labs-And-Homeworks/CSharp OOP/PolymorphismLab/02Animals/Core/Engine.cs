using System;

using Animals.Factories;
using Animals.Models;

namespace Animals.Core
{
    public class Engine
    {
        private readonly AnimalFactory animalFactory;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
        }

        public void Run()
        {
            Animal cat = this.animalFactory.CreateAnimal("Pesho", "Whiskas", "Cat");
            Animal dog = this.animalFactory.CreateAnimal("Gosho", "Meat", "Dog");

            PrintAnimals(cat, dog);
        }

        private void PrintAnimals(Animal cat, Animal dog)
        {
            Console.WriteLine(cat.ExplainSelf());

            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
