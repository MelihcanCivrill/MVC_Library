using MVC_Library.Models.DTO;
using MVC_Library.Models.ORM.Context;
using MVC_Library.Models.ORM.Entities.Abstract;
using MVC_Library.Models.ORM.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Library.Controllers
{
    public class BookController : Controller
    {
        public ApplicationDbContext _dbContext;
        public BookController() => _dbContext = new ApplicationDbContext();
        // GET: Book
        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(CreateBookDTO data)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book();
                book.Title = data.Title;
                book.Content = data.Content;
                book.Genre = data.Genre;
                book.ImageUrl = data.ImageUrl;
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();

                return View();
            }

            return View(data);
        }

        public ActionResult List()
        {
            List<Book> bookList = _dbContext.Books.Where(x => x.Status != Status.Passive).ToList();
            return View(bookList);
        }







        public ActionResult Update(int id)
        {
            Book book = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                UpdateBookDTO data = new UpdateBookDTO();
                data.Id = book.Id;
                data.Title = book.Title;
                data.Content = book.Content;
                data.ImageUrl = book.ImageUrl;
                data.Genre = book.Genre;
                return View(data);
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult Update(UpdateBookDTO data)
        {
            if (ModelState.IsValid)
            {
                Book book = _dbContext.Books.FirstOrDefault(x => x.Id == data.Id);

                book.Title = data.Title;
                book.Content = data.Content;
                book.ImageUrl = data.ImageUrl;
                book.Genre = data.Genre;
                book.UpdateDate = DateTime.Now;
                book.Status = Status.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("List");

            }
            else
            {
                return View(data);
            }

        }
        public ActionResult Delete(int id)
        {
            Book book = _dbContext.Books.Find(id);

            if (book != null)
            {
                book.Status = Status.Passive;
                book.DeleteDate = DateTime.Now;
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("List");
            }
        }

    }
}