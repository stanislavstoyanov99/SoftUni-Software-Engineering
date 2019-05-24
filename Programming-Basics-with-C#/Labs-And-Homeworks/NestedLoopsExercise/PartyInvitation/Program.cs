using System;

class Program
{
    static void Main(string[] args)
    {
        double totalCounterName = 0;
        double validNames = 0;
        double invalidNames = 0;

        bool isValidName = true;
        while (true)
        {
            string name = Console.ReadLine();
            if (name == "Statistic")
            {
                break;
            }

            isValidName = true;
            totalCounterName++;

            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    Console.WriteLine("Invalid name!");
                    isValidName = false;
                    invalidNames++;
                    break;
                }
            }

            if (isValidName)
            {
                validNames++;
                name = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1).ToLower();
                Console.WriteLine(name);
            }
        }

        double peopleComingPercent = (validNames / totalCounterName) * 100;
        double peopleNotComingPercent = (invalidNames / totalCounterName) * 100;

        Console.WriteLine($"Valid names are {peopleComingPercent:F2}% from {totalCounterName} names.");
        Console.WriteLine($"Invalid names are {peopleNotComingPercent:F2}% from {totalCounterName} names.");
    }
}
