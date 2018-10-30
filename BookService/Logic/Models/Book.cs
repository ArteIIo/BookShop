using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    /// <summary>
    /// Class with book model
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets book's id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets book's name
        /// </summary>
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets book's authors
        /// </summary>
        public List<BookAuthor> Authors { get; set; }

        /// <summary>
        /// Gets or sets book's genres
        /// </summary>
        public List<BookGenre> Genres { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            Authors = new List<BookAuthor>();
            Genres = new List<BookGenre>();
        }

        /// <summary>
        /// Set book's author to null
        /// </summary>
        public void RemoveAuthor()
        {
            Authors = null;
        }
    }
}
