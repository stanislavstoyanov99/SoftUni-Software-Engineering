using System;

class Program
{
    static void Main(string[] args)
    {
        double widthOfSpaceship = double.Parse(Console.ReadLine());
        double lengthOfSpaceship = double.Parse(Console.ReadLine());
        double heightOfSpaceship = double.Parse(Console.ReadLine());
        double averageHeight = double.Parse(Console.ReadLine());

        double racketArea = widthOfSpaceship * lengthOfSpaceship * heightOfSpaceship;
        double roomArea = (averageHeight + 0.40) * 2 * 2;
        double astonautsNumber = Math.Floor(racketArea / roomArea);
        if (astonautsNumber > 10)
        {
            Console.WriteLine("The spacecraft is too big.");
        }
        else if (astonautsNumber >= 3 && astonautsNumber <= 10)
        {
            Console.WriteLine($"The spacecraft holds {astonautsNumber} astronauts.");
        }
        else if (astonautsNumber < 3)
        {
            Console.WriteLine($"The spacecraft is too small.");
        }
    }
}
