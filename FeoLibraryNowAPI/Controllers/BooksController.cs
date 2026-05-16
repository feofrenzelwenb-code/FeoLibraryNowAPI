using FeoLibraryNowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeoLibraryNowAPI.Controllers
{
    [Route("apiv1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static
            List<Books> books = new List<Books>
            {
                new Books { Id = 1, Title="The Alchemist", Author="Paulo Coelho", Genre="Fiction", Available=true, PublishedYear= 1988 },
                 new Books { Id = 2, Title="The Fault in Our Stars", Author="John Green", Genre="Romance", Available=true, PublishedYear= 2012}

            };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { status = "success", data = books, message = "Books retrieved" });
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = books.FirstOrDefault(book => book.Id == id);
            if (book == null)
                return NotFound(new { status = "error", data = (object?)null, message = "Books not found" });
            return Ok(new { status = "success", data = book, message = "Book retrieved" });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Books newBook)
        {
            newBook.Id = books.Count + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetById), new { status = "success", data = newBook, message = "Book created" });

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Books updateBooks)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound(new { status = "error", data = (object?)null, message = "Book not Found." });
            book.Title = updateBooks.Title;
            book.Author = updateBooks.Author;
            book.Genre = updateBooks.Genre;
            book.Available = updateBooks.Available;
            book.PublishedYear = updateBooks.PublishedYear;

            return Ok(new { status = "success", data = book, message = "Book Updated." });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(book => book.Id == id);
            if (book == null)
                return NotFound(new { status = "error", data = (object?)null, message = "Book not Found" });

            book.Remove(book);
            return Ok(new { status = "success", data = book, message = "Books Deleted." });
        }
    }
}
