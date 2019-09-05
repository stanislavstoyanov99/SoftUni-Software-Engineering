using System;
using System.Linq;
using System.Reflection;

using StorageMaster.Models.Storages;

namespace StorageMaster.Core.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Type storageType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == type);

            if (storageType == null)
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            try
            {
                Storage storage = (Storage)Activator.CreateInstance(storageType, name);

                return storage;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
