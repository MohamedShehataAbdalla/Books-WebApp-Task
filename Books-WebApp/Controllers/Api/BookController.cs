using Books_WebApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Books_WebApp.Controllers.Api
{
    public class BookController : ApiController
    {
        private readonly AppDbContext _context;

        public BookController()
        {
            _context = new AppDbContext();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok();
        }
    }
}
