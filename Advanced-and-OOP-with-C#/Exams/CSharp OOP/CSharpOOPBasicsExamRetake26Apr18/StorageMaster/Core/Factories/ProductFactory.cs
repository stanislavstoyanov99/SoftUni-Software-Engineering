using System;
using System.Linq;
using System.Reflection;

using StorageMaster.Models.Products;

namespace StorageMaster.Core.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Type productType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == type);

            if (productType == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            try
            {
                Product product = (Product)Activator.CreateInstance(productType, price);

                return product;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
