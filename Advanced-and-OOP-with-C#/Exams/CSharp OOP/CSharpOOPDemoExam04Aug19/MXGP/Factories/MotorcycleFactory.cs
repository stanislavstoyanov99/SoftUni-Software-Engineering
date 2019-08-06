namespace MXGP.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using MXGP.Models.Motorcycles.Contracts;

    public class MotorcycleFactory
    {
        private const string SUFFIX = "Motorcycle";
        public IMotorcycle CreateMotorcycle(string type, string model, int horsePower)
        {
            Type motorCycleType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type + SUFFIX);

            if (motorCycleType == null)
            {
                throw new ArgumentNullException("Type is not found.");
            }

            try
            {
                IMotorcycle motorcycleInstance = (IMotorcycle)Activator.CreateInstance(motorCycleType, model, horsePower);

                return motorcycleInstance;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
