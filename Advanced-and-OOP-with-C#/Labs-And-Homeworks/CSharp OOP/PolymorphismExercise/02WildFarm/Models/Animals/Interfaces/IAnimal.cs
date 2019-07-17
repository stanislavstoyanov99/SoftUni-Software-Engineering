﻿using _02WildFarm.Models.Food.Interfaces;

namespace _02WildFarm.Models.Animals.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string AskForFood();

        void Feed(IFood food);
    }
}
