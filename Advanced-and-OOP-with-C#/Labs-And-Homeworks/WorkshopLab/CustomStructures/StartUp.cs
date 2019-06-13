using System;

namespace CustomStructures
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var list = new CustomList<int>();
            var secondList = new CustomList<int>(50);

            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(100);
            Console.WriteLine(stack.Peek());
            stack.Pop();

            stack.ForEach(Console.WriteLine);
        }
    }
}
