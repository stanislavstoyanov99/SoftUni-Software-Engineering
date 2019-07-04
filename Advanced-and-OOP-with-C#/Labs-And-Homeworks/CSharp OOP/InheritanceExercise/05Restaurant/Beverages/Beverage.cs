namespace Restaurant.Beverages
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, decimal milliliters) 
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        public decimal Milliliters { get; set; }
    }
}
