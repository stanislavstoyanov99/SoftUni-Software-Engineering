namespace SoftUniRestaurant.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using SoftUniRestaurant.Models.Tables.Contracts;

    public class TableFactory
    {
        private const string Suffix = "Table";

        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            try
            {
                Type typeToCreate = Assembly
                    .GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(t => t.Name == type + Suffix);

                object[] parameters = new object[]
                {
                    tableNumber,
                    capacity
                };

                ITable table = (ITable)Activator.CreateInstance(typeToCreate, parameters);

                return table;
            }
            catch (TargetInvocationException)
            {
                throw;
            }
        }
    }
}
