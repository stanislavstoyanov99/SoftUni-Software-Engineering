using System;
using System.Collections.Generic;

using _02WildFarm.Exceptions;
using _02WildFarm.Models.Animals.Interfaces;
using _02WildFarm.Models.Food.Interfaces;

namespace _02WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract List<Type> PreferredFoodTypes { get; }

        protected abstract double WeightMultiplier { get; }

        public abstract string AskForFood();

        public void Feed(IFood food)
        {
            if (!this.PreferredFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFoodTypeException,
                    this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
