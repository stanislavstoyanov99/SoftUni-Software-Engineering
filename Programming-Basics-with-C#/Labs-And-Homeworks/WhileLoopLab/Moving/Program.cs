using System;

class Program
{
    static void Main(string[] args)
    {
        int widthOfFreeSpace = int.Parse(Console.ReadLine());
        int lengthOfFreeSpace = int.Parse(Console.ReadLine());
        int heightOfFreeSpace = int.Parse(Console.ReadLine());

        int totalAreaOfBoxes = 0;

        int totalSpace = widthOfFreeSpace * lengthOfFreeSpace * heightOfFreeSpace;
        while (totalSpace > totalAreaOfBoxes)
        {
            string input = Console.ReadLine();
            if (input == "Done")
            {
                break;
            }
            else
            {
                int numberOfBoxes = int.Parse(input);
                totalAreaOfBoxes += numberOfBoxes;
            }
        }
        if (totalAreaOfBoxes > totalSpace)
        {
            int neededSpace = Math.Abs(totalAreaOfBoxes - totalSpace);
            Console.WriteLine($"No more free space! You need {neededSpace} Cubic meters more.");
        }
        if (totalSpace > totalAreaOfBoxes)
        {
            int emptySpace = Math.Abs(totalSpace - totalAreaOfBoxes);
            Console.WriteLine($"{emptySpace} Cubic meters left.");
        }
    }
}
