using System;

class Program
{
    static void Main(string[] args)
    {
        int juryMembers = int.Parse(Console.ReadLine());

        double gradesSum = 0;
        double averageGradesSum = 0;
        double totalGradesSum = 0;
        int totalGradesCounter = 0;

        while (true)
        {
            string presentationName = Console.ReadLine();
            if (presentationName == "Finish")
            {
                totalGradesSum /= totalGradesCounter;
                Console.WriteLine($"Student's final assessment is {totalGradesSum:F2}.");
                break;
            }

            for (int counter = 1; counter <= juryMembers; counter++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradesSum += grade;
                averageGradesSum = gradesSum / counter;
                totalGradesCounter++;
                totalGradesSum += grade;
            }
            Console.WriteLine($"{presentationName} - {averageGradesSum:F2}.");

            gradesSum = 0;
            averageGradesSum = 0;
        }
    }
}
