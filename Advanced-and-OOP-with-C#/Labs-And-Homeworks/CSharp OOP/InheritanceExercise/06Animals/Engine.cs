using Animals.Animals;
using System;
using System.Collections.Generic;

namespace Animals
{
    public class Engine
    {
        private List<Animal> animals;
        private string animalType;
        private string animalName;
        private int animalAge;
        private string animalGender;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                this.animalType = input;
                string[] animalInformation = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                this.animalName = animalInformation[0];
                this.animalAge = int.Parse(animalInformation[1]);
                this.animalGender = animalInformation[2];

                CreateAnimal();
            }

            PrintAnimalInformation();
        }

        private void PrintAnimalInformation()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private void CreateAnimal()
        {
            try
            {
                switch (this.animalType)
                {
                    case "Cat":
                        Cat cat = new Cat(animalName, animalAge, animalGender);
                        animals.Add(cat);
                        break;
                    case "Dog":
                        Dog dog = new Dog(animalName, animalAge, animalGender);
                        animals.Add(dog);
                        break;
                    case "Frog":
                        Frog frog = new Frog(animalName, animalAge, animalGender);
                        animals.Add(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(animalName, animalAge);
                        animals.Add(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(animalName, animalAge);
                        animals.Add(tomcat);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
