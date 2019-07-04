using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Cash
    {
        public Cash(string name, long quantity, Item item)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Item = item;
        }

        public string Name { get; set; }

        public long Quantity { get; set; }

        public Item Item { get; set; }
    }
}
