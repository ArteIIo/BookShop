using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    /// <summary>
    /// Internale type with Book-Genre pair
    /// </summary>
    public class BookGenre
    {
        /// <summary>
        /// Gets or sets book
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Gets or sets genre
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Override of object.Equal
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if their entity is equal</returns>
        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj != null && GetType() == obj.GetType())
            {
                BookGenre other = (BookGenre)obj;
                return Book.Equals(other.Book) && Genre.Equals(other.Genre);
            }

            return isEqual;
        }

        /// <summary>
        /// Override of object.GetHashCode
        /// </summary>
        /// <returns>HashCode of the object</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(Book, Genre).GetHashCode();
        }
    }
}
