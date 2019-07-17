using System;
using System.Collections.Generic;

using _02WildFarm.Models.Food.Entities;

namespace _02WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        protected override List<Type> PreferredFoodTypes =>
            new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 0.40;

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
