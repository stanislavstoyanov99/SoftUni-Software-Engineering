using System;

class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        string result = string.Empty;
        switch (number)
        {
            case 1: result = "Monday"; break;
            case 2: result = "Tuesday"; break;
            case 3: result = "Wednesday"; break;
            case 4: result = "Thursday"; break;
            case 5: result = "Friday"; break;
            case 6: result = "Saturday"; break;
            case 7: result = "Sunday"; break;
            default: Console.WriteLine("Error"); return;
        }
        Console.WriteLine(result);
    }
}
