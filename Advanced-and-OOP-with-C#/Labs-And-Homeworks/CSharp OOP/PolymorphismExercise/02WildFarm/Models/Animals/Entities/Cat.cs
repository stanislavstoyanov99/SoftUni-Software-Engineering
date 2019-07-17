using System;
using System.Collections.Generic;

using _02WildFarm.Models.Food.Entities;

namespace _02WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override List<Type> PreferredFoodTypes =>
            new List<Type> { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier => 0.30;

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
