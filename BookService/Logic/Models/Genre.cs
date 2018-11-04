using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    /// <summary>
    /// Class with book genre
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Gets or sets genre's id
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        /// <summary>
        /// Gets or sets genre's name
        /// </summary>
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets binded books
        /// </summary>
        public List<BookGenre> Books { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Genre"/> class.
        /// </summary>
        public Genre()
        {
            Books = new List<BookGenre>();
        }
    }
}
