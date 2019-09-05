using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using StorageMaster.Core.Contracts;
using StorageMaster.Core.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Core
{
    public class StorageMaster : IStorageMaster
    {
        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;

        private readonly List<Product> products;
        private readonly List<Storage> storageRegistry;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();

            this.products = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            this.products.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry.Add(storage);

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);
            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var productName in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.products.Any(t => t.GetType().Name == productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                // TODO
                Product product = this.products.FirstOrDefault(t => t.GetType().Name == productName);

                this.currentVehicle.LoadProduct(product);

                loadedProductsCount++;
            }

            int totalProductsCount = productNames.Count();

            return $"Loaded {loadedProductsCount}/{totalProductsCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storageRegistry.FirstOrDefault(t => t.Name == sourceName);

            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            Storage destinationLocation = this.storageRegistry.FirstOrDefault(t => t.Name == destinationName);

            if (destinationLocation == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            this.currentVehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int sourceCurrentGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationLocation);

            return $"Sent {currentVehicle.GetType().Name} to {destinationName} (slot {sourceCurrentGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);

            int productsInVehicle = vehicle.Trunk.Count;

            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            var filteredProducts = storage.Products
                .GroupBy(x => x.GetType().Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Name)
                .Select(x => $"{x.Name} ({x.Count})")
                .ToList();

            var resultProducts = string.Join(", ", filteredProducts);

            double sumOfProductWeight = storage.Products.Sum(x => x.Weight);

            var vehicles = storage.Garage.ToArray();
            var vehicleNames = vehicles
                .Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            string result = $"Stock ({sumOfProductWeight}/{storage.Capacity}): [{resultProducts}]" +
                Environment.NewLine +
                $"Garage: [{string.Join("|", vehicleNames)}]";

            return result;
        }

        public string GetSummary()
        {
            var storages = this.storageRegistry
                .OrderByDescending(x => x.Products.Sum(y => y.Price))
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var storage in storages)
            {
                sb.AppendLine($"{storage.Name}:");

                double totalMoney = storage.Products.Sum(y => y.Price);

                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
