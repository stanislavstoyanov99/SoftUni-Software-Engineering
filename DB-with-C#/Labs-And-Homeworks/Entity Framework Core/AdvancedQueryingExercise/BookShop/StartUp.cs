namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;

    using BookShop.Data;
    using BookShop.Models;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new BookShopContext();

            int lengthCheck = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(db, lengthCheck));
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

        // Problem 02. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEditionBooks = context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.EditionType,
                    b.Copies
                })
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Join(Environment.NewLine, goldenEditionBooks
                .Select(b => b.Title)));

            return sb.ToString().TrimEnd();
        }

        // Problem 03. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksWithPrices = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksWithPrices)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 04. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var notReleasedBooks = context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Join(Environment.NewLine, notReleasedBooks
                .Select(b => b.Title)));

            return sb.ToString().TrimEnd();
        }

        // Problem 05. Book Titles by Category 
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(" ",
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<Book> resultBooks = new List<Book>();

            foreach (var category in categories)
            {
                var booksByCategory = context.Books
                    .Where(b => b.BookCategories
                    .Any(b => b.Category.Name.ToLower() == category.ToLower()))
                    .Select(b => new Book
                    {
                        Title = b.Title,
                        BookCategories = b.BookCategories
                    })
                    .ToList();

                resultBooks.AddRange(booksByCategory);
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Join(Environment.NewLine, resultBooks
                .Select(b => b.Title)
                .OrderBy(x => x)));

            return sb.ToString().TrimEnd();
        }

        // Problem 06. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            var booksReleasedBefore = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .Where(b => b.ReleaseDate.Value.Date < targetDate)
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 07. Author Search 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsEndingIn = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Join(Environment.NewLine, authorsEndingIn
                .Select(a => a.FullName)));

            return sb.ToString().TrimEnd();
        }

        // Problem 08. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitlesContaining = context
                .Books
                .Select(b => new
                {
                    b.Title
                })
                .Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Join(Environment.NewLine, bookTitlesContaining
                .Select(b => b.Title)));

            return sb.ToString().TrimEnd();
        }

        // Problem 09. Book Search by Author 
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context
                .Books
                .Where(b => b.Author.LastName
                .StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByAuthor)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }
    }
}
