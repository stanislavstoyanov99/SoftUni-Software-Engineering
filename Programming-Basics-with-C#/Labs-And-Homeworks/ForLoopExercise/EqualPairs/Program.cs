using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int previousSum = 0;
        int currentSum = 0;
        int currentDiff = 0;
        int maxDiff = 0;

        for (int count = 1; count <= number; count++)
        {
            previousSum = currentSum;
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            currentSum = first + second;

            currentDiff = Math.Abs(currentSum - previousSum);

            if (previousSum != currentSum && count >= 2)
            {
                maxDiff = currentDiff;
            }
            if (currentDiff > maxDiff && count >= 2)
            {
                maxDiff = currentDiff;
            }
        }
        //if (maxDiff != 0)
        //{
        //    Console.WriteLine($"No, maxdiff = {maxDiff}");
        //}
        //else
        //{
        //    Console.WriteLine($"Yes, value = {currentSum}");
        //}

        string result = maxDiff != 0 ? $"No, maxdiff={maxDiff}" : $"Yes, value = {currentSum}";
        Console.WriteLine(result);
    }
}
