namespace LaptopShop
{
    public class Laptop
    {
        public string Make { get; private set; }

        public string Model { get; private set; }

        public double DisplaySize { get; private set; }

        public decimal Price { get; private set; }

        public int Ram { get; private set; }

        public int? Ssd { get; private set; }

        public Laptop(string make, string model, double displaySize, decimal price, int ram, int? ssd)
        {
            Make = make;
            Model = model;
            DisplaySize = displaySize;
            Price = price;
            Ram = ram;
            Ssd = ssd;
        }

        public string FullInfo()
        {
            return $"Make: {Make}";
        }
    }
}
