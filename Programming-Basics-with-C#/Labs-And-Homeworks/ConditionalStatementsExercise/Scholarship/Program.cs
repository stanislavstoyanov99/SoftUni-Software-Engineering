using System;

class Program
{
    static void Main(string[] args)
    {
        double income = double.Parse(Console.ReadLine());
        double averageWork = double.Parse(Console.ReadLine());
        double minimumWorkingSalary = double.Parse(Console.ReadLine());

        double socialScholarship = 0.0;
        double excellentScholarship = 0.0;
        double result = 0.0;

        socialScholarship = minimumWorkingSalary * 0.35;
        excellentScholarship = averageWork * 25;

        if (averageWork <= 4.50)
        {
            Console.WriteLine("You cannot get a scholarship!");
        }
        else if (averageWork > 4.50 && averageWork < 5.50)
        {
            if (income > minimumWorkingSalary)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else
            {
                result = socialScholarship;
                Console.WriteLine($"You get a Social scholarship {Math.Floor(result)} BGN");
            }
        }
        else if (averageWork >= 5.50)
        {
            if (income < minimumWorkingSalary)
            {
                result = excellentScholarship;
                if (result >= socialScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(result)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
            }
            else
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
            }
        }
    }
}