﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
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
        private ILibrary library;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenresController"/> class.
        /// </summary>
        /// <param name="library">Service with genre's collection</param>
        public GenresController(ILibrary library)
        {
            this.library = library;
        }

        /// <summary>
        /// Get-method for all genre's collection
        /// </summary>
        /// <returns>Ok if there is a service with genre</returns>
        // GET api/genres
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
        /// <param name="id">Index of the needed genre</param>
        /// <returns>Ok if there is a genre by such index</returns>
        // GET api/genres/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;
            try
            {
                result = Ok(library.GetGenreByIndex(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                result = NotFound();
            }

            return result;
        }

        /// <summary>
        /// A post method for creation of the new genre
        /// </summary>
        /// <param name="genre">Need genre</param>
        /// <returns>CreateAtAction result if author
        /// has been created or bad request otherwise</returns>
        // POST api/genres
        [HttpPost]
        public IActionResult Post([FromBody] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            library.AddGenre(genre);

            return CreatedAtAction("Get", new { id = genre.Id }, genre);
        }

        /// <summary>
        /// Delete selected genre
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>Ok if genre has beed deleted</returns>
        // DELETE api/genres/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult result;
            try
            {
                Genre deleted = library.RemoveGenre(id);
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