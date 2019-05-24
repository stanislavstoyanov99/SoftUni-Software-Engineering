using System;

class Program
{
    static void Main(string[] args)
    {
        int winnerCombination = int.Parse(Console.ReadLine());

        int counter = 0;

        for (char firstSymbol = 'B'; firstSymbol <= 'L'; firstSymbol++)
        {
            for (char secondSymbol = 'f'; secondSymbol >= 'a'; secondSymbol--)
            {
                for (char thirdSymbol = 'A'; thirdSymbol <= 'C'; thirdSymbol++)
                {
                    for (int rowNumber = 1; rowNumber <= 10; rowNumber++)
                    {
                        for (int seatNumber = 10; seatNumber >= 1; seatNumber--)
                        {
                            if (firstSymbol % 2 == 0)
                            {
                                string ticketCombination = "" + firstSymbol + secondSymbol + thirdSymbol + rowNumber + seatNumber;
                                counter++;
                                int rewardPrize = firstSymbol + secondSymbol + thirdSymbol + rowNumber + seatNumber;
                                if (counter == winnerCombination)
                                {
                                    Console.WriteLine($"Ticket combination: {ticketCombination}");
                                    Console.WriteLine($"Prize: {rewardPrize} lv.");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
