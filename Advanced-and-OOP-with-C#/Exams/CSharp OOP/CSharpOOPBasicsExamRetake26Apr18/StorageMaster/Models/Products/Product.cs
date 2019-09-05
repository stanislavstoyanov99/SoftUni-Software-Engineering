namespace StorageMaster.Models.Products
{
    using System;

    using StorageMaster.Models.Contracts;

    public abstract class Product : IProduct
    {
        private double price;
        public Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get => this.price;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public double Weight { get; private set; }
    }
}
