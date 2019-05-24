using System;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int maxGoals = 0;
            string winner = string.Empty;
            bool hetTrick = false;

            while (true)
            {
                string playerName = command;
                int scoredGoals = int.Parse(Console.ReadLine());

                if (scoredGoals >= 3) //когато има хетрик
                {
                    hetTrick = true;
                }

                if (scoredGoals > maxGoals)
                {
                    winner = playerName;
                    maxGoals = scoredGoals;
                }
                if (scoredGoals >= 10) //програмата спира, ако са вкарани 10 или повече гола
                {
                    break;
                }
                command = Console.ReadLine();
                if (command == "END") //Ако се напише END, програмата спира.
                {
                    break;
                }
            }
            Console.WriteLine($"{winner} is the best player!"); //Резултат за това кой е вкарал най-много голове

            if (hetTrick) //проверка дали има хетрик
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
