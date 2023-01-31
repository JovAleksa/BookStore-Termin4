using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore.Controllers
{
    public class BookStoreController : Controller
    {
        public static List<BookModel> books = new List<BookModel>();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult Add(BookModel book)
        {
            if (!ModelState.IsValid)
            {
                if (book.Name == null)
                {
                    ViewBag.FirstNameError = "Please write name of book";
                }
                else if(book.Price==0)
                {
                    ViewBag.SecondNameError = "Please write book price ";
                }
                return View("index");
            }
            if (books.Count == 0)
            {
                books.Add(book);
            }
            else
            {
                foreach (BookModel bookModel in books)
                {
                    if (bookModel.Name.Contains(book.Name))
                    {
                        ViewBag.FirstNameError = "The book already exists.";
                        return View("index");

                    }                 

                }
                books.Add(book);
            }

            return RedirectToAction("ListAll");
        }
        public IActionResult Delete(int Id, string fname)
        {
            foreach (BookModel bm in books)
            {
                if (bm.id == Id)
                {
                    bm.Deleted = true;
                    break;
                }
            }
            return RedirectToAction(fname);
        }
      
        public IActionResult ListAll()
        {

            ViewBag.book = books;
            return View();
        }

        public IActionResult DeleteList()
        {
            ViewBag.book = books;
            return View();

        }

        public IActionResult Sortiraj(int smer, string fname)
        {
            List<BookModel> sortirani = new List<BookModel>();
            sortirani = smer == 1 ? books.OrderBy(x => x.Name).ToList() : smer == 2 ? books.OrderByDescending(x => x.Name).ToList() : smer == 3 ? books.OrderBy(x => x.Price).ToList() : books.OrderByDescending(x => x.Price).ToList();
            ViewBag.book = sortirani;
            return View(fname);
        }
       


    }
}
