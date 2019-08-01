namespace SoftUniRestaurant.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using SoftUniRestaurant.Models.Drinks.Contracts;

    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
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
                    servingSize,
                    brand
                };

                IDrink drink = (IDrink)Activator.CreateInstance(typeToCreate, parameters);

                return drink;
            }
            catch (TargetInvocationException)
            {
                throw;
            }
        }
    }
}
