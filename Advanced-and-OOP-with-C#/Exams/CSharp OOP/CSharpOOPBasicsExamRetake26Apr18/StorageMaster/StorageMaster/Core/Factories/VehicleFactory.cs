using System;
using System.Linq;
using System.Reflection;

using StorageMaster.Models.Vehicles;

namespace StorageMaster.Core.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Type vehicleType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == type);

            if (vehicleType == null)
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            try
            {
                Vehicle vehicle = (Vehicle)Activator.CreateInstance(vehicleType);

                return vehicle;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
