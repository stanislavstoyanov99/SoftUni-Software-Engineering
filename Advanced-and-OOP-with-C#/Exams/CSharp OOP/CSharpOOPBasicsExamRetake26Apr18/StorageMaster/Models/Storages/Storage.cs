using System;
using System.Linq;
using System.Collections.Generic;

using StorageMaster.Models.Contracts;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage : IStorage
    {
        private readonly Vehicle[] garage;

        private readonly List<Product> products;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[this.GarageSlots];
            this.products = new List<Product>();

            this.InitializeGarage(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            bool hasDeliveryGarageFreeSlot = deliveryLocation.Garage.Any(x => x == null);

            if (!hasDeliveryGarageFreeSlot)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;

            int addedSlot = deliveryLocation.AddVehicle(vehicle);

            return addedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int numberOfUnloadedProducts = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product unpackedProduct = vehicle.Unload();
                this.products.Add(unpackedProduct);

                numberOfUnloadedProducts++;
            }

            return numberOfUnloadedProducts;
        }

        private int AddVehicle(Vehicle vehicle)
        {
            int freeGarageSlotIndex = Array.IndexOf(this.garage, null);

            this.garage[freeGarageSlotIndex] = vehicle;

            return freeGarageSlotIndex;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            int garageSlot = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[garageSlot++] = vehicle;
            }
        }
    }
}
