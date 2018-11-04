using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    /// <summary>
    /// Controller for CRUD opertions
    /// with genre
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        /// <summary>
        /// Service with genre collection
        /// </summary>
        private IGenreService genres;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenresController"/> class.
        /// </summary>
        /// <param name="genres">Service with genre's collection</param>
        public GenresController(IGenreService genres)
        {
            this.genres = genres;
        }

        /// <summary>
        /// Get-method for all genre's collection
        /// GET api/genres
        /// </summary>
        /// <returns>Ok if there is a service with genre</returns>
        [HttpGet]
        public IActionResult GetGenres()
        {
            return Ok(genres.GetGenres());
        }

        /// <summary>
        /// Get-method for a author by it's id
        /// GET api/genres/5
        /// </summary>
        /// <param name="id">Index of the needed genre</param>
        /// <returns>Ok if there is a genre by such id</returns>
        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(genres.GetGenreById(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// A post method for creation of the new genre
        /// POST api/genres
        /// </summary>
        /// <param name="genre">Need genre</param>
        /// <returns>CreateAtAction result if author
        /// has been created or bad request otherwise</returns
        [HttpPost]
        public IActionResult CreateGenre([FromBody] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            genres.AddGenre(genre);

            return CreatedAtAction("Get", new { id = genre.GenreId }, genre);
        }

        /// <summary>
        /// Delete selected genre
        /// DELETE api/genres/5
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>Ok if genre has beed deleted</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            IActionResult result;
            try
            {
                Genre deleted = genres.RemoveGenre(id);
                if (deleted != null)
                {
                    result = Ok(deleted);
                }
                else
                {
                    result = BadRequest();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }
    }
}