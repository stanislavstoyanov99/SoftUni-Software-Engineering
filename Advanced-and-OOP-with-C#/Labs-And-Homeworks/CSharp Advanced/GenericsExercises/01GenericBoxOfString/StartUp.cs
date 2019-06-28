using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < numberOfStrings; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
