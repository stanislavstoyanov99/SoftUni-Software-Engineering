using System;

namespace CustomLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.AddLast("Pesho");
            doublyLinkedList.AddLast("Gosho");
            doublyLinkedList.AddLast("Kiro");

            doublyLinkedList.Print(Console.WriteLine);
            string[] array = doublyLinkedList.ToArray();

            Console.WriteLine(doublyLinkedList.Contains("Gosho"));
        }
    }
}
