namespace _08BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<char> stackOfParanteses = new Stack<char>();
            char[] input = Console.ReadLine().ToCharArray();

            char[] openParaneteses = new char[] { '(', '{', '[' };

            bool isValid = true;

            foreach (var item in input)
            {
                if (openParaneteses.Contains(item))
                {
                    stackOfParanteses.Push(item);
                    continue;
                }

                if (stackOfParanteses.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stackOfParanteses.Peek() == '(' && item == ')')
                {
                    stackOfParanteses.Pop();
                }
                else if (stackOfParanteses.Peek() == '[' && item == ']')
                {
                    stackOfParanteses.Pop();
                }
                else if (stackOfParanteses.Peek() == '{' && item == '}')
                {
                    stackOfParanteses.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
