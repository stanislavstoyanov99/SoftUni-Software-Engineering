using System;

namespace _01PartyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int coins = days * 50; // for each day we earn 50 coins so that we multiply days to 50

            for (int day = 1; day <= days; day++) // loop all days
            {
                if (day % 15 == 0) // for every 15-th day
                {
                    partySize += 5;
                }

                if (day % 10 == 0) // for every 10-th day
                {
                    partySize -= 2;
                }

                if (day % 5 == 0) // for every 5-th day
                {
                    int earnedCoins = 20; // we earn 20 coins
                    coins += earnedCoins * partySize; // total coins are these earned coins multiplied by the party size
                    if (day % 3 == 0) // for every 3-th day 
                    {
                        coins -= partySize * 2;
                    }
                }

                if (day % 3 == 0) // for every 3-th day
                {
                    coins -= partySize * 3;
                }

                coins -= partySize * 2; // for every day
            }

            int coinsPerCompanion = coins / partySize; // find the coins per companion

            Console.WriteLine($"{partySize} companions received {coinsPerCompanion} coins each.");
        }
    }
}
