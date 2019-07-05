using System.Collections.Generic;
using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> names = new List<string> { "Stefan", "Pesho", "Kiro" };

            var stack = new StackOfStrings<string>();
            stack.AddRange(names);

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
