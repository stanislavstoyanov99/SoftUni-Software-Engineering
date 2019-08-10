namespace StorageMaster.Models.Vehicles
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using StorageMaster.Models.Contracts;
    using StorageMaster.Models.Products;

    public abstract class Vehicle : IVehicle
    {
        private readonly List<Product> products;

        private Vehicle()
        {
            this.products = new List<Product>();
        }

        public Vehicle(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk =>
            this.products.AsReadOnly();

        public bool IsFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public bool IsEmpty => this.products.Count == 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.products.Add(product);
        }

        public Product Unload()
        {
            if (this.products.Count == 0)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product lastProduct = this.products.Last();

            this.products.Remove(lastProduct);

            return lastProduct;
        }
    }
}
