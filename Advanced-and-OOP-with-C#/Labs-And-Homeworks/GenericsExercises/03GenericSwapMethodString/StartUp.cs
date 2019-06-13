using System;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfBoxes = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < numberOfBoxes; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            string[] swapInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int firstIndex = int.Parse(swapInfo[0]);
            int secondIndex = int.Parse(swapInfo[1]);

            box.Swap(firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}
