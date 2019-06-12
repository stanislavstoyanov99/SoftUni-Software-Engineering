using System;
using System.Collections.Generic;

namespace _06Wardrobe
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" -> ");

                string color = tokens[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                string[] clothes = tokens[1].Split(",");
                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color].Add(clothes[j], 0);
                    }

                    wardrobe[color][clothes[j]]++;
                }
            }

            string[] targetClothInfo = Console.ReadLine().Split(" ");

            string targetColor = targetClothInfo[0];
            string targetCloth = targetClothInfo[1];

            foreach (var (color, clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (cloth, count) in clothes)
                {
                    string result = $"* {cloth} - {count}";

                    if (color == targetColor && cloth == targetCloth)
                    {
                        result += " (found!)";
                    }

                    Console.WriteLine(result);
                }
            }
        }
    }
}
