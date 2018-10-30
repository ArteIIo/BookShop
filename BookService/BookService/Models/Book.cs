using System.ComponentModel.DataAnnotations;

namespace BookService
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
        [MinLength(2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets book's author
        /// </summary>
        public string Author { get; set; }
    }
}
