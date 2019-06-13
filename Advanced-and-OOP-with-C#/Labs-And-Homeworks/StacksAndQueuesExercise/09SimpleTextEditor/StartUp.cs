namespace _09SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stackOfText = new Stack<string>();
            StringBuilder text = new StringBuilder();

            int numberOfOperations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                if (command == "1")
                {
                    stackOfText.Push(text.ToString());
                    text.Append(input[1]);
                }
                else if (command == "2")
                {
                    int length = int.Parse(input[1]);
                    int startIndex = text.Length - length;

                    stackOfText.Push(text.ToString());
                    text.Remove(startIndex, length);
                }
                else if (command == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (input[0] == "4" && stackOfText.Count > 0)
                {
                    text.Clear();
                    text.Append(stackOfText.Pop());
                }
            }
        }
    }
}
