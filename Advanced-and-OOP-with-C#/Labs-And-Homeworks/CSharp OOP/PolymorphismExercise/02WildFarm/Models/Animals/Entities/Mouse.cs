using System;
using System.Collections.Generic;

using _02WildFarm.Models.Food.Entities;

namespace _02WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        protected override List<Type> PreferredFoodTypes =>
            new List<Type> { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplier => 0.10;

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
