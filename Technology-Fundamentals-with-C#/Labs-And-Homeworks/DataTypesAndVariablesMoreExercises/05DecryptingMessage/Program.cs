using System;

namespace _05DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());

            string message = string.Empty;
            for (int i = 0; i < numberOfLines; i++)
            {
                char character = char.Parse(Console.ReadLine());
                char characterWithKey = (char)(character + key);
                message += characterWithKey;
            }

            Console.WriteLine(message);
        }
    }
}
