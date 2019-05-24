using System;

class Program
{
    static void Main(string[] args)
    {
        int widthOfFreeSpace = int.Parse(Console.ReadLine());
        int lengthOfFreeSpace = int.Parse(Console.ReadLine());
        int heightOfFreeSpace = int.Parse(Console.ReadLine());

        double packagesArea = widthOfFreeSpace * lengthOfFreeSpace * heightOfFreeSpace;
        double currentPackagesArea = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Done")
            {
                if (packagesArea > currentPackagesArea)
                {
                    double leftSpace = Math.Abs(currentPackagesArea - packagesArea);
                    Console.WriteLine($"{leftSpace} Cubic meters left.");
                }
                break;
            }
            int packagesNumber = int.Parse(input);
            currentPackagesArea += packagesNumber;
            double neededSpace = Math.Abs(packagesArea - currentPackagesArea);

            if (currentPackagesArea > packagesArea)
            {
                Console.WriteLine($"No more free space! You need {neededSpace} Cubic meters more.");
                break;
            }
        }
    }
}
