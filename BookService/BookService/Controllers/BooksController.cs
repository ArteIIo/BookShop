using System;
using System.Collections.Generic;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    /// <summary>
    /// Controller for CRUD opertions
    /// with books
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Service with books collection
        /// </summary>
        private ILibrary library;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="library">Service with book's collection</param>
        public BooksController(ILibrary library)
        {
            this.library = library;
        }

        /// <summary>
        /// Get-method for all book's collection
        /// GET api/books
        /// </summary>
        /// <returns>Ok if there is a service with books</returns>
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(library.GetBooks());
        }

        /// <summary>
        /// Get-method for a book by it's id
        /// GET api/books/5
        /// </summary>
        /// <param name="id">Index of the needed book</param>
        /// <returns>Ok if there is a book by such id</returns>
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(library.GetBookById(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        ///  Get-method for a book by it's author
        /// </summary>
        /// <param name="id">Author's id</param>
        /// <returns>Ok if there are books with such author</returns>
        [HttpGet("search-author/{id}")]
        public IActionResult GetByAuthor(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(library.SearchByAuthor(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        ///  Get-method for a book by it's genre
        /// </summary>
        /// <param name="id">Genre's id</param>
        /// <returns>Ok if there are books with such genre</returns>
        [HttpGet("search-genre/{id}")]
        public IActionResult GetByGenre(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(library.SearchByGenre(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// A post method for creation of the new book
        /// POST api/books
        /// </summary>
        /// <param name="book">Need book</param>
        /// <returns>CreateAtAction result if book
        /// has been created or bad request otherwise</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            library.AddBook(book);

            return CreatedAtAction("Get", new { id = book.Id }, book);
        }

        /// <summary>
        /// Update selected book
        /// PUT api/books/5
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <param name="book">New book's values</param>
        /// <returns>CreateAtAction result if book
        /// has been updated or bad request otherwise</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
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
                    library.SetBookById(book, id);
                    result = CreatedAtAction("Get", new { id = book.Id }, book);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                result = BadRequest();
            }

            return result;
        }

        /// <summary>
        /// Update book's author
        /// </summary>
        /// <param name="authorId">Index of the author</param>
        /// <param name="bookId">Index of the book</param>
        /// <returns>Ok if operation was successful</returns>
        [HttpPut("author-update/{authorId}/{bookId}")]
        public IActionResult UpdateAuthor(int authorId, int bookId)
        {
            IActionResult result;
            try
            {
                library.UpdateAuthor(authorId, bookId);
                result = Ok();
            }
            catch (IndexOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// Update book's genre
        /// </summary>
        /// <param name="genreId">Index of the genre</param>
        /// <param name="bookId">Index of the book</param>
        /// <returns>Ok if operation was successful</returns>
        [HttpPut("genre-update/{genreId}/{bookId}")]
        public IActionResult UpdateGenre(int genreId, int bookId)
        {
            IActionResult result;
            try
            {
                library.UpdateGenre(genreId, bookId);
                result = Ok();
            }
            catch (IndexOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// Delete selected book
        /// DELETE api/books/5
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Ok if book has beed deleted</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            IActionResult result;
            try
            {
                Book deleted = library.RemoveBook(id);
                result = Ok(deleted);
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }
    }
}