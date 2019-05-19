using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleInput = Console.ReadLine().Split(", ");
            string title = articleInput[0];
            string content = articleInput[1];
            string author = articleInput[2];

            Article article = new Article(title, content, author);
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ");
                string command = tokens[0];

                if (command == "Edit")
                {
                    string newContet = tokens[1];
                    article.Edit(newContet);
                }
                else if (command == "ChangeAuthor")
                {
                    string newAuthor = tokens[1];
                    article.ChangeAuthor(newAuthor);
                }
                else if (command == "Rename")
                {
                    string newTitle = tokens[1];
                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
