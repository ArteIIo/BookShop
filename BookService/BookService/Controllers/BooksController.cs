using System.Collections.Generic;
using BookService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookCollection books;

        public BooksController(IBookCollection books)
        {
            this.books = books;
        }

        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            if(books == null)
            {
                return NotFound();
            }

            return Ok(books.GetBooks());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            if (books.Size - 1 < id)
            {
                return NotFound();
            }

            return Ok(books[id]);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            books.Add(book);

            return CreatedAtAction("Get", new { id = book.Id }, book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid || id > books.Size - 1)
            {
                return BadRequest();
            }

            books[id] = book;

            return CreatedAtAction("Get", new { id = book.Id }, book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (books.Size - 1 < id)
            {
                return NotFound();
            }

            Book deleted = books.Remove(id);

            return Ok(deleted);
        }
    }
}