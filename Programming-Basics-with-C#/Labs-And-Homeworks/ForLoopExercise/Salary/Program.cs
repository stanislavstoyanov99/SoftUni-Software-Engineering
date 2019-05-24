using System;

class Program
{
    static void Main(string[] args)
    {
        int openTabs = int.Parse(Console.ReadLine());
        int salary = int.Parse(Console.ReadLine());

        const int FB = 150;
        const int Instagram = 100;
        const int Reddit = 50;

        for (int count = 0; count < openTabs; count++)
        {
            string website = Console.ReadLine();
            switch (website)
            {
                case "Facebook": salary -= FB; break;
                case "Instagram": salary -= Instagram; break;
                case "Reddit": salary -= Reddit; break;
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
                return;
            }
        }
        Console.WriteLine($"{salary}");
    }
}
