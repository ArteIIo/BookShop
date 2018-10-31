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
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets book's name
        /// </summary>
        [MinLength(2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets book's author
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Set book's author to null
        /// </summary>
        public void RemoveAuthor()
        {
            Author = null;
        }
    }
}
