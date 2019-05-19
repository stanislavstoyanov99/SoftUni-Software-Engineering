using System;
using System.Collections.Generic;
using System.Linq;

namespace _07StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxList = new List<Box>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split(" ");
                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                decimal itemPrice = decimal.Parse(data[3]);

                decimal priceBox = itemQuantity * itemPrice;

                Box currentBox = new Box()
                {
                    SerialNumber = serialNumber,
                    ItemQuantity = itemQuantity,
                    PriceBox = priceBox
                };

                currentBox.Item.Name = itemName;
                currentBox.Item.Price = itemPrice;

                boxList.Add(currentBox);
            }

            boxList = boxList.OrderByDescending(x => x.PriceBox).ToList();

            foreach (var box in boxList)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceBox { get; set; }
    }
}
