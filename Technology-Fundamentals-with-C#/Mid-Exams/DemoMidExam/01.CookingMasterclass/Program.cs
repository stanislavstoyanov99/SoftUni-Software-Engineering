using System;

class Program
{
    static void Main(string[] args)
    {
        decimal budget = decimal.Parse(Console.ReadLine());
        int students = int.Parse(Console.ReadLine());
        decimal flourPrice = decimal.Parse(Console.ReadLine());
        decimal eggPrice = decimal.Parse(Console.ReadLine());
        decimal apronPrice = decimal.Parse(Console.ReadLine());

        int freePackages = students / 5;  //изчисляваме безплатните пакети брашно

        decimal totalPrice = (apronPrice * Math.Ceiling(students * 1.2m)) + //цена за aprons (студентите ги увеличаваме с 20% и закръгляме нагоре)
                             (eggPrice * 10 * students) +                   //цена за яйцата
                             (flourPrice * (students - freePackages));      //цена за брашно минус безплатните пакети

        Console.WriteLine(budget >= totalPrice ?
            $"Items purchased for {totalPrice:F2}$." :
            $"{ (totalPrice - budget):F2}$ more needed.");  //принтираме резултата
    }
}

