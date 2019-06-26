using System;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Push")
                {
                    for (int currentNumber = 1; currentNumber < tokens.Length; currentNumber++)
                    {
                        stack.Push(int.Parse(tokens[currentNumber]));
                    }
                }
                else if (command == "Pop")
                {
                    stack.Pop();
                }
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }
        }
    }
}
