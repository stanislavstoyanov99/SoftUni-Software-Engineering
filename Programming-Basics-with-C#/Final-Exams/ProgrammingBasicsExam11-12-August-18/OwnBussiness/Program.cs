using System;

class Program
{
    static void Main(string[] args)
    {
        int widthOfFreeSpace = int.Parse(Console.ReadLine());
        int lengthOfFreeSpace = int.Parse(Console.ReadLine());
        int heightOfFreeSpace = int.Parse(Console.ReadLine());

        int hallArea = widthOfFreeSpace * lengthOfFreeSpace * heightOfFreeSpace;

        int currentArea = 0;
        bool isFreeSpaceAvailable = true;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Done")
            {
                break;
            }

            int inputAsNumber = int.Parse(input);
            currentArea += inputAsNumber;
            if (currentArea > hallArea)
            {
                isFreeSpaceAvailable = false;
                break;
            }
        }

        if (!isFreeSpaceAvailable)
        {
            int neededSpace = currentArea - hallArea;
            Console.WriteLine($"No more free space! You need {neededSpace} Cubic meters more.");
        }
        else
        {
            int leftSpace = hallArea - currentArea;
            Console.WriteLine($"{leftSpace} Cubic meters left.");
        }
    }
}
