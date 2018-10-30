using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        /// <summary>
        /// Service with authors collection
        /// </summary>
        private ILibrary library;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="library">Service with author's collection</param>
        public AuthorsController(ILibrary library)
        {
            this.library = library;
        }

        /// <summary>
        /// Get-method for all author's collection
        /// </summary>
        /// <returns>Ok if there is a service with author</returns>
        // GET api/authors
        [HttpGet]
        public IActionResult Get()
        {
            if (library == null)
            {
                return NotFound();
            }

            return Ok(library.GetAuthors());
        }

        /// <summary>
        /// Get-method for a author by it's index
        /// </summary>
        /// <param name="id">Index of the needed author</param>
        /// <returns>Ok if there is a author by such index</returns>
        // GET api/authors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(library.GetAuthorByIndex(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// A post method for creation of the new author
        /// </summary>
        /// <param name="author">Need author</param>
        /// <returns>CreateAtAction result if author
        /// has been created or bad request otherwise</returns>
        // POST api/authors
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            library.AddAuthor(author);

            return CreatedAtAction("Get", new { id = author.Id }, author);
        }

        /// <summary>
        /// Update selected book
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <param name="author">New author's values</param>
        /// <returns>CreateAtAction result if book
        /// has been updated or bad request otherwise</returns>
        // PUT api/author/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
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
                    library.SetAuthorByIndex(author, id);
                    result = CreatedAtAction("Get", new { id = author.Id }, author);
                }
            }
            catch (ArgumentOutOfRangeException)
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
        // DELETE api/author/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result;
            try
            {
                Author deleted = library.RemoveAuthor(id);
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