using System;

class Program
{
    static void Main(string[] args)
    {
        int badGrades = int.Parse(Console.ReadLine());

        int countOfBadGrades = 0;
        int count = 0;
        double totalGrade = 0.0;
        string lastProblem = string.Empty;

        while (true)
        {
            string nameOfExercise = Console.ReadLine();
            if (nameOfExercise == "Enough")
            {
                double averageGrade = totalGrade / count;
                Console.WriteLine($"Average score: {averageGrade:F2}");
                Console.WriteLine($"Number of problems: {count}");
                Console.WriteLine($"Last problem: {lastProblem}");
                break;
            }
            int grade = int.Parse(Console.ReadLine());

            if (grade <= 4)
            {
                countOfBadGrades++;
            }
            if (countOfBadGrades == badGrades)
            {
                Console.WriteLine($"You need a break, {countOfBadGrades} poor grades.");
                break;
            }

            lastProblem = nameOfExercise;
            totalGrade += grade;
            count++;
        }
    }
}
