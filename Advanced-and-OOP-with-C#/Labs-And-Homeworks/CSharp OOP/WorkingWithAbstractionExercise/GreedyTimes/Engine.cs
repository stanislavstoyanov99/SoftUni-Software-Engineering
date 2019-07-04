using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Engine
    {
        private List<Cash> cashItems;
        private List<Gem> gemItems;
        private List<Gold> goldItems;

        public Engine()
        {
            this.cashItems = new List<Cash>();
            this.gemItems = new List<Gem>();
            this.goldItems = new List<Gold>();
        }

        public void Run()
        {
            long maxCapacity = long.Parse(Console.ReadLine());
            string[] itemPairs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            long goldQuantity = 0;
            long stonesQuantity = 0;
            long cashQuantity = 0;

            for (int i = 0; i < itemPairs.Length; i += 2)
            {
                string name = itemPairs[i];
                long quantity = long.Parse(itemPairs[i + 1]);

                Item item = new Item(name, quantity);

                if (name.Length == 3)
                {
                    Cash cash = new Cash(name, quantity, item);
                    cashItems.Add(cash);
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    Gem gem = new Gem(name, quantity, item);
                    gemItems.Add(gem);
                }
                else if (name.ToLower() == "gold")
                {
                    Gold gold = new Gold(name, quantity, item);
                    goldItems.Add(gold);
                }

                long cashItemsQuantity = cashItems.Sum(x => x.Quantity);
                long goldItemsQuantity = goldItems.Sum(x => x.Quantity);
                long gemItemsQuantity = gemItems.Sum(x => x.Quantity);

                long currentCapacity = cashItemsQuantity + goldItemsQuantity + gemItemsQuantity + quantity;
                if (maxCapacity < currentCapacity)
                {
                    continue;
                }

                // TODO
                switch (item.Name)
                {
                    case "Gem":
                        if (!this.gemItems.Contains(currentType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentType].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(currentType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[currentType].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(currentType))
                {
                    bag[currentType] = new Dictionary<string, long>();
                }

                if (!bag[currentType].ContainsKey(name))
                {
                    bag[currentType][name] = 0;
                }

                bag[currentType][name] += quantity;

                if (name == "Gold")
                {
                    goldQuantity += quantity;
                }
                else if (name == "Cash")
                {
                    cashQuantity += quantity;
                }
                else if (name == "Gem")
                {
                    stonesQuantity += quantity;
                }
            }

            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}
