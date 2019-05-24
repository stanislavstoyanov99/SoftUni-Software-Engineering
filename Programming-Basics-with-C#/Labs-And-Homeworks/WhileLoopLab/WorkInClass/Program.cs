using System;
namespace WorkInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            int gradesCount = 0;
            double gradesSum = 0;

            while (gradesCount < 12)
            {
                double currentGrade = double.Parse(Console.ReadLine());

                gradesSum = gradesSum + currentGrade;
                if (currentGrade >= 4)
                {
                    gradesCount++;
                }
            }
            double averageGrade = gradesSum / 12;
            Console.WriteLine($"{studentName} graduated. Average grade: {averageGrade:F2}");
        }
    }
}
