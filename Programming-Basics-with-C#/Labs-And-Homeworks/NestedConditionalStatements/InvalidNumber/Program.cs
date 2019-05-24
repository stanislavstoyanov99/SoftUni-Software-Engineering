using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        string result = string.Empty;
        bool isNumberValid = (100 <= number && number <= 200) && number != 0;
        if (!isNumberValid)
        {
            result = "invalid";
        }
        Console.WriteLine(result);
    }
}
