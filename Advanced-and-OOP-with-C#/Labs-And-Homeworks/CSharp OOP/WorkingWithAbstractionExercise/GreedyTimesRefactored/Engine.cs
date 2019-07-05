using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Engine
    {
        private Dictionary<string, Dictionary<string, long>> bag;
        private long bagCapacity;
        private long goldQuantity;
        private long stonesQuantity;
        private long cashQuantity;

        public Engine()
        {
            this.bag = new Dictionary<string, Dictionary<string, long>>();
        }

        public void Run()
        {
            bagCapacity = long.Parse(Console.ReadLine());
            string[] itemInformation = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < itemInformation.Length; i += 2)
            {
                string itemName = itemInformation[i];
                long itemQuantity = long.Parse(itemInformation[i + 1]);

                string itemType = this.GetItemType(itemName);

                bool isDataValid = this.ValidateData(itemType, itemQuantity);
                bool isProcessingDataValid = this.CheckProcessingData(itemType, itemQuantity);

                if (isDataValid || isProcessingDataValid)
                {
                    continue;
                }

                this.SetItemQuantity(itemName, itemQuantity, itemType);

                this.AddCounterValues(itemQuantity, itemType);
            }

            PrintBag();
        }

        private void PrintBag()
        {
            foreach (var itemType in bag)
            {
                long itemTotalSum = itemType.Value.Values.Sum();

                Console.WriteLine($"<{itemType.Key}> ${itemTotalSum}");

                var filterItemValues = itemType.Value
                    .OrderByDescending(y => y.Key)
                    .ThenBy(y => y.Value)
                    .ToList();

                foreach (var item in filterItemValues)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private void AddCounterValues(long itemQuantity, string itemType)
        {
            if (itemType == "Gold")
            {
                goldQuantity += itemQuantity;
            }
            else if (itemType == "Gem")
            {
                stonesQuantity += itemQuantity;
            }
            else if (itemType == "Cash")
            {
                cashQuantity += itemQuantity;
            }
        }

        private void SetItemQuantity(string itemName, long itemQuantity, string itemType)
        {
            if (!bag.ContainsKey(itemType))
            {
                bag[itemType] = new Dictionary<string, long>();
            }

            if (!bag[itemType].ContainsKey(itemName))
            {
                bag[itemType][itemName] = 0;
            }

            bag[itemType][itemName] += itemQuantity;
        }

        private bool CheckProcessingData(string itemType, long itemQuantity)
        {
            bool result = false;

            switch (itemType)
            {
                case "Gem":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (itemQuantity > bag["Gold"].Values.Sum())
                            {
                                result = true;
                            }
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + itemQuantity > bag["Gold"].Values.Sum())
                    {
                        result = true;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(itemType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (itemQuantity > bag["Gem"].Values.Sum())
                            {
                                result = true;
                            }
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else if (bag[itemType].Values.Sum() + itemQuantity > bag["Gem"].Values.Sum())
                    {
                        result = true;
                    }
                    break;
            }

            return result;
        }

        private bool ValidateData(string itemType, long currentQuantity)
        {
            bool result = false;
            long maxQuantity = bag.Values.Select(x => x.Values.Sum()).Sum() + currentQuantity;

            if (itemType == string.Empty)
            {
                result = true;
            }
            else if (bagCapacity < maxQuantity)
            {
                result = true;
            }

            return result;
        }

        private string GetItemType(string itemName)
        {
            string itemType = string.Empty;

            if (itemName.Length == 3)
            {
                itemType = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                itemType = "Gold";
            }

            return itemType;
        }
    }
}
