using System;
using BookService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    /// <summary>
    /// Controller for CRUD opertions
    /// with biooks for Task1
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Service with books collection
        /// </summary>
        private IBookCollection books;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="books">Service with book's collection</param>
        public BooksController(IBookCollection books)
        {
            this.books = books;
        }

        /// <summary>
        /// Get-method for all book's collection
        /// </summary>
        /// <returns>Ok if there is a service with books</returns>
        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books.GetBooks());
        }

        /// <summary>
        /// Get-method for a book by it's index
        /// </summary>
        /// <param name="id">Index of the needed book</param>
        /// <returns>Ok if there is a book by such index</returns>
        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(books[id]);
            }
            catch (IndexOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// A post method for creation of the new book
        /// </summary>
        /// <param name="book">Need book</param>
        /// <returns>CreateAtAction result if book
        /// has been created or bad request otherwise</returns>
        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            books.Add(book);

            return CreatedAtAction("Get", new { id = book.Id }, book);
        }

        /// <summary>
        /// Update selected book
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <param name="book">New book's values</param>
        /// <returns>CreateAtAction result if book
        /// has been updated or bad request otherwise</returns>
        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            IActionResult result;
            try
            {
                if (!ModelState.IsValid)
                {
                    result = BadRequest();
                }
                else
                {
                    books[id] = book;
                    result = CreatedAtAction("Get", new { id = book.Id }, book);
                }
            }
            catch (IndexOutOfRangeException)
            {
                result = BadRequest();
            }

            return result;
        }

        /// <summary>
        /// Delete selected book
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Ok if book has beed deleted</returns>
        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result;
            try
            {
                Book deleted = books.Remove(id);
                result = Ok(deleted);
            }
            catch (IndexOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }
    }
}