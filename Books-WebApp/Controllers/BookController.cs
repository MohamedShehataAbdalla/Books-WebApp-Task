using Books_WebApp.Models;
using Books_WebApp.Models.Data;
using Books_WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Net;

namespace Books_WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController()
        {
            _context = new AppDbContext();
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = _context.Books.Include( x => x.Categories).ToList();
            return View(books);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _context.Books.Include(m => m.Categories).SingleOrDefault(m => m.Id == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        public ActionResult Create()
        {
            var viewModel = new BookViewModel
            {
                Categories = _context.Categories.Where(x => x.Active).ToList(),
            };
            return View("BookForm", viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var book = _context.Books.Find(id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                Categories = _context.Categories.Where(m => m.Active).ToList()
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _context.Categories.Where(x => x.Active).ToList();
                return View("BookForm", model);
            }

            if (model.Id == 0)
            {
                // Store
                var book = new Book
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = model.Author,
                    CategoryId = model.CategoryId,
                };

                _context.Books.Add(book);
            }
            else
            {
                // Update

                var book = _context.Books.Find(model.Id);

                if (book == null)
                    return HttpNotFound();

                book.Title = model.Title;
                book.Description = model.Description;
                book.Author = model.Author;
                book.CategoryId = model.CategoryId;

                _context.Books.AddOrUpdate(book);
            }
                
            _context.SaveChanges();

            TempData["Message"] = "Saved successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}