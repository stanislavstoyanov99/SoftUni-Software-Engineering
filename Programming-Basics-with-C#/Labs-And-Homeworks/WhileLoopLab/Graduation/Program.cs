using System;

class Program
{
    static void Main(string[] args)
    {
        string studentName = Console.ReadLine();
        double counter = 0;
        double totalSum = 0;

        while (counter < 12)
        {
            double currentGrade = double.Parse(Console.ReadLine());
            if (currentGrade >= 4)
            {
                counter++;
                totalSum += currentGrade;
            }
        }

        double averageGrade = totalSum / 12;
        Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:F2}");
    }
}
