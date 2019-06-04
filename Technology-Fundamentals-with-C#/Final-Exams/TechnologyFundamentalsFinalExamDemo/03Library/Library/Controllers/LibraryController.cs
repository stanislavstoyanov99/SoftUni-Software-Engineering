using System.Linq;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            {
                var allBooks = db.Tasks.ToList();
                return View(allBooks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string author, double price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) 
                || string.IsNullOrEmpty(price.ToString()))
            {
                return RedirectToAction("Index");
            }

            Book book = new Book
            {
                Title = title,
                Author = author,
                Price = price
            };

            using (var db = new LibraryDbContext())
            {
                db.Tasks.Add(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (bookToEdit == null)
                {
                    return RedirectToAction("Index");
                }

                return View(bookToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.Tasks.FirstOrDefault(t => t.Id == book.Id);
                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;
                bookToEdit.Price = book.Price;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelete = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (bookToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                return View(bookToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelete = db.Tasks.FirstOrDefault(t => t.Id == book.Id);

                if (bookToDelete == null)
                {
                    RedirectToAction("Index");
                }

                db.Tasks.Remove(bookToDelete);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}