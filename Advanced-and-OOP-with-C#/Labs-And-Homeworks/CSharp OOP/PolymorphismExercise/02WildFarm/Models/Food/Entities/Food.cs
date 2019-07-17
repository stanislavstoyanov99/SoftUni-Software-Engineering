using _02WildFarm.Models.Food.Interfaces;

namespace _02WildFarm.Models.Food.Entities
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
