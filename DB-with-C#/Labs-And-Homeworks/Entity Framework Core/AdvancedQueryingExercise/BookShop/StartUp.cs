namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    using BookShop.Data;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new BookShopContext();

            string command = Console.ReadLine();

            Console.WriteLine(GetBooksByAgeRestriction(db, command));
        }

        // Problem 01. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction age = Enum.Parse<AgeRestriction>(command, true);

            var bookTitles = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.AgeRestriction
                })
                .Where(b => b.AgeRestriction == age)
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Join(Environment.NewLine, bookTitles
                .Select(b => b.Title)));

            return sb.ToString().TrimEnd();
        }
    }
}
