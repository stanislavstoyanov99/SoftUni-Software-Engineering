using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Item
    {
        public Item(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public long Quantity { get; set; }
    }
}
