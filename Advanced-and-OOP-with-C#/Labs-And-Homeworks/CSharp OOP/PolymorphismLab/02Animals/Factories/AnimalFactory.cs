using Animals.Models;

namespace Animals.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string name, string favouriteFood, string type)
        {
            Animal animal = null;

            if (type == "Cat")
            {
                animal = new Cat(name, favouriteFood);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, favouriteFood);
            }

            return animal;
        }
    }
}
