using System;

class Program
{
    static void Main(string[] args)
    {
        int passengersNumber = int.Parse(Console.ReadLine());
        int stopsNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= stopsNumber; i++)
        {
            if (i % 2 == 0)
            {
                passengersNumber -= 2;
            }
            else
            {
                passengersNumber += 2;
            }
            int outPassengers = int.Parse(Console.ReadLine());
            int inPassengers = int.Parse(Console.ReadLine());

            passengersNumber = Math.Abs((passengersNumber - outPassengers) + inPassengers);
        }
        Console.WriteLine($"The final number of passengers is : {passengersNumber}");
    }
}
