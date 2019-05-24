using System;

class Program
{
    static void Main(string[] args)
    {
        string animal = Console.ReadLine().ToLower();
        string animalType = string.Empty;

        switch (animal)
        {
            case "dog": animalType = "mammal"; break;
            case "crocodile":
            case "tortoise":
            case "snake": animalType = "reptile"; break;
            default: Console.WriteLine("unknown"); return;
        }
        Console.WriteLine(animalType);
    }
}
