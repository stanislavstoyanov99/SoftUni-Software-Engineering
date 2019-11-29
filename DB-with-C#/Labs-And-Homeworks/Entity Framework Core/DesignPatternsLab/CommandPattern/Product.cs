namespace CommandPattern
{
    using System;

    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void IncreasePrice(int amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price for the {this.Name} has been increased by {amount}$.");
        }

        public void DecreasePrice(int amount)
        {
            if (amount < this.Price)
            {
                this.Price -= amount;
                Console.WriteLine($"The price for the {this.Name} has been decrease by {amount}$.");
            }
        }

        public override string ToString() => $"Current price for the {this.Name} product is {this.Price}$.";
    }
}
