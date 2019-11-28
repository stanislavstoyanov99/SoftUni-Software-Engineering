namespace Composite
{
    using System;
    using System.Collections.Generic;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly List<GiftBase> gifts;

        public CompositeGift(string name, decimal price)
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal totalSum = 0;

            Console.WriteLine($"{Name} contains the following products with prices:");

            foreach (GiftBase gift in this.gifts)
            {
                totalSum += gift.CalculateTotalPrice();
            }

            return totalSum;
        }
    }
}
