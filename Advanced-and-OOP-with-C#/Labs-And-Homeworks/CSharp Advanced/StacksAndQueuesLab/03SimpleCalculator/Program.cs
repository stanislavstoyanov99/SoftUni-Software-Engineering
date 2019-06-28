using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] expression = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(expression.Reverse());

            while (stack.Count > 1)
            {
                int firstOperand = int.Parse(stack.Pop());
                string opr = stack.Pop();
                int secondOperand = int.Parse(stack.Pop());

                switch (opr)
                {
                    case "+":
                        stack.Push($"{firstOperand + secondOperand}");
                        break;
                    case "-":
                        stack.Push($"{firstOperand - secondOperand}");
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
