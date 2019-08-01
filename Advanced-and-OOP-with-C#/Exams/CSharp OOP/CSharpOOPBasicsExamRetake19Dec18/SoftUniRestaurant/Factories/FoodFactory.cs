namespace SoftUniRestaurant.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using SoftUniRestaurant.Models.Foods.Contracts;

    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            try
            {
                Type typeToCreate = Assembly
                    .GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == type);

                object[] parameters = new object[]
                {
                    name,
                    price
                };

                IFood food = (IFood)Activator.CreateInstance(typeToCreate, parameters);

                return food;
            }
            catch (TargetInvocationException)
            {
                throw;
            }
        }
    }
}
