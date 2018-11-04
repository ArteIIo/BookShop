using System;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    /// <summary>
    /// Controller for author
    /// Controller for CRUD opertions
    /// with authors
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        /// <summary>
        /// Service with authors collection
        /// </summary>
        private IAuthorService authors;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="authors">Service with author's collection</param>
        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        /// <summary>
        /// Get-method for all author's collection
        /// GET api/authors
        /// </summary>
        /// <returns>Ok if there is a service with author</returns>
        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(authors.GetAuthors());
        }

        /// <summary>
        /// Get-method for a author by it's id
        /// GET api/authors/5
        /// </summary>
        /// <param name="id">Index of the needed author</param>
        /// <returns>Ok if there is a author by such id</returns>
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(authors.GetAuthorById(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// A post method for creation of the new author
        /// POST api/authors
        /// </summary>
        /// <param name="author">Need author</param>
        /// <returns>CreateAtAction result if author
        /// has been created or bad request otherwise</returns>
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            authors.AddAuthor(author);

            return CreatedAtAction("Get", new { id = author.AuthorId }, author);
        }

        /// <summary>
        /// Update selected author
        /// PUT api/authors/5
        /// </summary>
        /// <param name="id">Index of the selected author</param>
        /// <param name="author">New author's values</param>
        /// <returns>CreateAtAction result if author
        /// has been updated or bad request otherwise</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] Author author)
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
                    authors.SetAuthorById(author, id);
                    result = CreatedAtAction("Get", new { id = author.AuthorId }, author);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                result = BadRequest();
            }

            return result;
        }

        /// <summary>
        /// Delete selected author
        /// DELETE api/author/5
        /// </summary>
        /// <param name="id">Index of the selected author</param>
        /// <returns>Ok if author has beed deleted</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            IActionResult result;
            try
            {
                Author deleted = authors.RemoveAuthor(id);
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