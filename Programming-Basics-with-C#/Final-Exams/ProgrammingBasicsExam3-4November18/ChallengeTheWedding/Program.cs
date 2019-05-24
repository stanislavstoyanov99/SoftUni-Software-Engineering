using System;

class Program
{
    static void Main(string[] args)
    {
        int man = int.Parse(Console.ReadLine());
        int women = int.Parse(Console.ReadLine());
        int totalTables = int.Parse(Console.ReadLine());

        int counter = 0;
        for (int i = 1; i <= man; i++)
        {
            for (int j = 1; j <= women; j++)
            {
                Console.Write($"({i} <-> {j}) ");
                counter++;
                if (counter == totalTables)
                {
                    return;
                }
            }
        }
        Console.WriteLine();
    }
}
