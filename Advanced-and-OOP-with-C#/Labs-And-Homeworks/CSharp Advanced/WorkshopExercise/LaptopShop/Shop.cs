using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopShop
{
    public class Shop
    {
        private Dictionary<string, List<Laptop>> laptops;

        public Shop()
        {
            this.laptops = new Dictionary<string, List<Laptop>>();
        }

        public int Count => this.laptops.Count;

        public void AddLaptop(Laptop laptop)
        {
            CheckIfNull(laptop);

            if (!this.laptops.ContainsKey(laptop.Make))
            {
                this.laptops.Add(laptop.Make, new List<Laptop>());
            }

            this.laptops[laptop.Make].Add(laptop);
        }


        public bool RemoveLaptop(Laptop laptop)
        {
            CheckIfNull(laptop);

            if (!this.laptops.ContainsKey(laptop.Make))
            {
                return false;
            }

            if (this.laptops[laptop.Make].Contains(laptop))
            {
                return false;
            }

            bool isRemoved = this.laptops[laptop.Make].Remove(laptop);

            if (this.laptops[laptop.Make].Count == 0)
            {
                isRemoved = this.laptops.Remove(laptop.Make);
            }

            return isRemoved;
        }

        public void PrintAllLaptops(Action<Laptop> action)
        {
            foreach (var (make, dictLaptops) in laptops)
            {
                foreach (var laptop in dictLaptops)
                {
                    action(laptop);
                }
            }
        }

        private static void CheckIfNull(Laptop laptop)
        {
            if (laptop == null)
            {
                throw new ArgumentNullException(nameof(laptop), "Object cannot be null!");
            }
        }
        //Shop
        //-Laptops ?
        //-Count
        //--AddLaptop
        //--RemoveLaptop
        //--ContainsLaptop
        //--PrintAllLaptops
    }
}
