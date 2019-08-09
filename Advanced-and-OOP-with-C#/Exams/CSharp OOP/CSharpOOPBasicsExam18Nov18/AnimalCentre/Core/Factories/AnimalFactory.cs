using System;
using System.Linq;
using System.Reflection;

using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Type animalType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (animalType == null)
            {
                throw new ArgumentNullException(nameof(animalType), "Animal type could not be found.");
            }

            object[] parameters = new object[]
            {
                name,
                energy,
                happiness,
                procedureTime
            };

            try
            {
                IAnimal animal = (IAnimal)Activator.CreateInstance(animalType, parameters);

                return animal;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
