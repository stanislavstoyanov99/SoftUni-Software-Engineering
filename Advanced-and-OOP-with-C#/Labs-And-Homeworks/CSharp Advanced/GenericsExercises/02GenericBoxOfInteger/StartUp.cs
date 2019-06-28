using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < numberOfStrings; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Add(input);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
