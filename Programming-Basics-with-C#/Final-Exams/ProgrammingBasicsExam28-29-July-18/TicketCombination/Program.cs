using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfCombination = int.Parse(Console.ReadLine());
        int counter = 0;

        for (char nameOfStadium = 'B'; nameOfStadium <= 'L'; nameOfStadium++)
        {
            for (char nameOfSector = 'f'; nameOfSector >= 'a'; nameOfSector--)
            {
                for (char entrance = 'A'; entrance <= 'C'; entrance++)
                {
                    for (int row = 1; row <= 10; row++)
                    {
                        for (int seat = 10; seat >= 1; seat--)
                        {
                            if (nameOfStadium % 2 == 0)
                            {
                                string combination = "" + nameOfStadium + nameOfSector + entrance + row + seat;
                                int rewardPrice = nameOfStadium + nameOfSector + entrance + row + seat;
                                counter++;
                                if (numberOfCombination == counter)
                                {
                                    Console.WriteLine($"Ticket combination: {combination}");
                                    Console.WriteLine($"Prize: {rewardPrice} lv.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
