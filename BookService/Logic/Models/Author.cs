using System.ComponentModel.DataAnnotations;

namespace Logic.Models
{
    /// <summary>
    /// Class with author model
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Gets or sets author's id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets author's name
        /// </summary>
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets author's surname
        /// </summary>
        [Required]
        [MinLength(2)]
        public string Surname { get; set; }
    }
}
