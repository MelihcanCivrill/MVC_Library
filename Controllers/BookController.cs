using MVC_Library.Models.DTO;
using MVC_Library.Models.ORM.Context;
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


    }
}