using System;

class Program
{
    static void Main(string[] args)
    {
        int widthOfCake = int.Parse(Console.ReadLine());
        int lengthOfCake = int.Parse(Console.ReadLine());
        int totalCake = widthOfCake * lengthOfCake;
        bool finished = true;

        string result = string.Empty;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "STOP")
            {
                break;
            }
            totalCake -= int.Parse(input);
            if (totalCake < 0)
            {
                finished = false;
                break;
            }
        }
        if (finished == false)
        {
            result = $"No more cake left! You need {Math.Abs(totalCake)} pieces more.";
        }
        else
        {
            result = $"{totalCake} pieces are left.";
        }
        Console.WriteLine(result);
    }
}
