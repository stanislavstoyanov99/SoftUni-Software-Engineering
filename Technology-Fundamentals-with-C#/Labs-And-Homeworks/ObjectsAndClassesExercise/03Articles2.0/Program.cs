using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            Storage storage = new Storage(); // create new object storage from the class Storage
            for (int i = 1; i <= numberOfArticles; i++)
            {
                string[] currentArticle = Console.ReadLine().Split(", ");
                string title = currentArticle[0];
                string content = currentArticle[1];
                string author = currentArticle[2];

                storage.Articles.Add(new Article(title, content, author)); // add new object to the storage list Articles
            }

            string inputCriteria = Console.ReadLine();

            if (inputCriteria == "title")
            {
                storage.Articles = storage.Articles.OrderBy(t => t.Title).ToList(); // alphabetical order by title of the article
            }
            else if (inputCriteria == "content")
            {
                storage.Articles = storage.Articles.OrderBy(t => t.Content).ToList(); // alphabetical order by content of the article
            }
            else if (inputCriteria == "author")
            {
                storage.Articles = storage.Articles.OrderBy(t => t.Author).ToList(); // alphabetical order by author of the article
            }

            Console.WriteLine(storage); // print the articles list
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Storage
    {
        public List<Article> Articles { get; set; }

        public Storage()
        {
            Articles = new List<Article>();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Articles);
        }
    }
}
