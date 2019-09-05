namespace ViceCity.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ViceCity.Utilities.Messages;
    using ViceCity.Models.Guns.Contracts;

    public class GunFactory
    {
        public IGun InitializeGun(string type, string name)
        {
            try
            {
                Type gunToCreate = Assembly
                    .GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == type);

                if (gunToCreate == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunTypeNotFound);
                }

                IGun gun = (IGun)Activator.CreateInstance(gunToCreate, name);

                return gun;
            }
            catch (TargetInvocationException)
            {
                throw;
            }
        }
    }
}
