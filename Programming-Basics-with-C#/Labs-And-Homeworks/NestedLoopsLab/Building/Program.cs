using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfFloors = int.Parse(Console.ReadLine());
        int numberOfRoomsPerFloor = int.Parse(Console.ReadLine());

        for (int numberOfFloorsIndex = numberOfFloors; numberOfFloorsIndex >= 1; numberOfFloorsIndex--)
        {
            for (int numberOfRoomsIndex = 0; numberOfRoomsIndex < numberOfRoomsPerFloor; numberOfRoomsIndex++)
            {
                if (numberOfFloorsIndex == numberOfFloors)
                {
                    Console.Write($"L{numberOfFloorsIndex}{numberOfRoomsIndex} ");
                }
                else if (numberOfFloorsIndex % 2 == 0) // evenFloor
                {
                    Console.Write($"O{numberOfFloorsIndex}{numberOfRoomsIndex} ");
                }
                else // oddFloor
                {
                    Console.Write($"A{numberOfFloorsIndex}{numberOfRoomsIndex} ");
                }
            }
            Console.WriteLine();
        }
    }
}
