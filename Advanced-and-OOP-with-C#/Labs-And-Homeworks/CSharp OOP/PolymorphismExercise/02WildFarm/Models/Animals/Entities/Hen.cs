using System;
using System.Collections.Generic;

using _02WildFarm.Models.Food.Entities;

namespace _02WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        protected override List<Type> PreferredFoodTypes => 
            new List<Type> { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeightMultiplier => 0.35;

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
