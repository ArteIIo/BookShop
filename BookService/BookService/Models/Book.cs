using System.ComponentModel.DataAnnotations;

namespace BookService
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
