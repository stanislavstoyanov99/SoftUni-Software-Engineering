using System;

class Program
{
    static void Main(string[] args)
    {
        string bookName = Console.ReadLine();
        int capacityOfLibrary = int.Parse(Console.ReadLine());

        string currentBook = string.Empty;
        int bookCounter = 0;

        while (bookCounter < capacityOfLibrary)
        {
            currentBook = Console.ReadLine();
            
            if (currentBook == bookName)
            {
                Console.WriteLine($"You checked {bookCounter} books and found it.");
                break;
            }
            bookCounter++;
        }
        if (currentBook != bookName)
        {
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {bookCounter} books.");
        }
    }
}
