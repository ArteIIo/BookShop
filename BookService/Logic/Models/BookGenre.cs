using System;

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
        public int BookIndex { get; set; }

        /// <summary>
        /// Gets or sets genre
        /// </summary>
        public int GenreIndex { get; set; }

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
                return BookIndex.Equals(other.BookIndex) && GenreIndex.Equals(other.GenreIndex);
            }

            return isEqual;
        }

        /// <summary>
        /// Override of object.GetHashCode
        /// </summary>
        /// <returns>HashCode of the object</returns>
        public override int GetHashCode()
        {
            return BookIndex ^ GenreIndex;
        }
    }
}
