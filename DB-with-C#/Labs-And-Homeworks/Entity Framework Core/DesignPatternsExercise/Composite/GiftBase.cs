namespace Composite
{
    public abstract class GiftBase
    {
        public GiftBase(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        protected string Name { get; private set; }

        protected decimal Price { get; private set; }

        public abstract decimal CalculateTotalPrice();
    }
}
