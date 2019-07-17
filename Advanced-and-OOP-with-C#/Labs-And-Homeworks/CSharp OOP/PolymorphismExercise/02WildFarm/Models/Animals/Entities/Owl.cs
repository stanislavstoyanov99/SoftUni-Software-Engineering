using System;
using System.Collections.Generic;

using _02WildFarm.Models.Food.Entities;

namespace _02WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        protected override List<Type> PreferredFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 0.25;

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
