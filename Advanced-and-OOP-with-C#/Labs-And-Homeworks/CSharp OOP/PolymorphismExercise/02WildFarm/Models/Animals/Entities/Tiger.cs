using System;
using System.Collections.Generic;

using _02WildFarm.Models.Food.Entities;

namespace _02WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        protected override List<Type> PreferredFoodTypes =>
            new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 1.00;

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
