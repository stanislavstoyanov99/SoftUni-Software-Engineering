using System;

class Program
{
    static void Main(string[] args)
    {
        string productType = Console.ReadLine().ToLower();
        string result = string.Empty;
        switch (productType)
        {
            case "banana":
            case "apple":
            case "kiwi":
            case "cherry":
            case "lemon":
            case "grapes": result = "fruit"; break;
            case "tomato":
            case "cucumber":
            case "pepper":
            case "carrot": result = "vegetable"; break;
            default: result = "unknown"; break;
        }
        Console.WriteLine(result);
    }
}
