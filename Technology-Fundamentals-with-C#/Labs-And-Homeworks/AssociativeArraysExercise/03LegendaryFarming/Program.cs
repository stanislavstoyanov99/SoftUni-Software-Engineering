using System;
using System.Collections.Generic;
using System.Linq;

namespace _03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, int>
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };
            var junkItems = new Dictionary<string, int>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int amount = int.Parse(tokens[i]);
                    string material = tokens[i + 1].ToLower();

                    if (materials.ContainsKey(material))
                    {
                        materials[material] += amount;
                        if (materials[material] >= 250)
                        {
                            PrintResult(materials, junkItems, material);
                            return;
                        }
                    }
                    else
                    {
                        if (junkItems.ContainsKey(material))
                        {
                            junkItems[material] += amount;
                        }
                        else
                        {
                            junkItems.Add(material, amount);
                        }
                    }
                }
            }
        }

        private static void PrintResult(Dictionary<string, int> materials,
            Dictionary<string, int> junkItems, string material)
        {
            switch (material)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
            }

            materials[material] -= 250;

            var materialsOutput = materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            foreach (var currentMaterial in materialsOutput)
            {
                Console.WriteLine($"{currentMaterial.Key}: {currentMaterial.Value}");
            }

            var junkItemsOutput = junkItems.OrderBy(x => x.Key);
            foreach (var junkItem in junkItemsOutput)
            {
                Console.WriteLine($"{junkItem.Key}: {junkItem.Value}");
            }
        }
    }
}
