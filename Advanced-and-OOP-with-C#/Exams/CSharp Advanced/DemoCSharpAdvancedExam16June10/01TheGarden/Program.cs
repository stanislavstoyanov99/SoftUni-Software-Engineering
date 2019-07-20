using System;

namespace _01TheGarden
{
    class Program
    {
        static string[][] garden;
        static int targetRow;
        static int targetCol;
        static int harmedVegetablesCount;
        static int harvestedCarrotCount;
        static int harvestedLettuceCount;
        static int harvestedPotatoesCount;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            garden = new string[rows][];

            InitializeGarden();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End of Harvest")
            {
                string[] commandsInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandsInfo[0];
                targetRow = int.Parse(commandsInfo[1]);
                targetCol = int.Parse(commandsInfo[2]);

                if (command == "Harvest")
                {
                    HarvestTheGarden();
                }
                else if (command == "Mole")
                {
                    string direction = commandsInfo[3];
                    MoleDirection(direction);
                }
            }

            PrintGarden();
        }

        private static void PrintGarden()
        {
            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Carrots: {harvestedCarrotCount}");
            Console.WriteLine($"Potatoes: {harvestedPotatoesCount}");
            Console.WriteLine($"Lettuce: {harvestedLettuceCount}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetablesCount}");
        }

        private static void InitializeGarden()
        {
            for (int row = 0; row < garden.Length; row++)
            {
                string[] vegetables = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                garden[row] = new string[vegetables.Length];

                for (int col = 0; col < vegetables.Length; col++)
                {
                    garden[row][col] = vegetables[col];
                }
            }
        }

        private static void MoleDirection(string direction)
        {
            if (IsInside(targetRow, targetCol))
            {
                if (direction == "up")
                {
                    for (int row = targetRow; row >= 0; row -= 2)
                    {
                        if (garden[row][targetCol] != " ")
                        {
                            garden[row][targetCol] = " ";
                            harmedVegetablesCount++;
                        }
                    }
                }
                else if (direction == "down")
                {
                    for (int row = targetRow; row < garden.Length; row += 2)
                    {
                        if (garden[row][targetCol] != " ")
                        {
                            garden[row][targetCol] = " ";
                            harmedVegetablesCount++;
                        }
                    }
                }
                else if (direction == "left")
                {
                    for (int col = targetCol; col >= 0; col -= 2)
                    {
                        if (garden[targetRow][col] != " ")
                        {
                            garden[targetRow][col] = " ";
                            harmedVegetablesCount++;
                        }
                    }
                }
                else if (direction == "right")
                {
                    for (int col = targetCol; col < garden[targetRow].Length; col += 2)
                    {
                        if (garden[targetRow][col] != " ")
                        {
                            garden[targetRow][col] = " ";
                            harmedVegetablesCount++;
                        }
                    }
                }
            }
        }

        private static void HarvestTheGarden()
        {
            if (IsInside(targetRow, targetCol))
            {
                if (garden[targetRow][targetCol] == "C")
                {
                    harvestedCarrotCount++;
                    garden[targetRow][targetCol] = " ";
                }
                else if (garden[targetRow][targetCol] == "L")
                {
                    harvestedLettuceCount++;
                    garden[targetRow][targetCol] = " ";
                }
                else if (garden[targetRow][targetCol] == "P")
                {
                    harvestedPotatoesCount++;
                    garden[targetRow][targetCol] = " ";
                }
            }
        }

        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow >= 0 && desiredRow < garden.Length 
                && desiredCol >= 0 && desiredCol < garden[desiredRow].Length;
        }
    }
}