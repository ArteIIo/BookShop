using System.Collections.Generic;

namespace BookService.Models
{
    /// <summary>
    /// Interface of the book's collecton
    /// </summary>
    public interface IBookCollection
    {
        /// <summary>
        /// Gets size of the collection
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Remove book by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="System.IndexOutOfRangeException">Throw if index out of range</exception>
        Book this[int id] { get; set; }

        /// <summary>
        /// Return collection of books
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book">New book</param>
        void Add(Book book);

        /// <summary>
        /// Remove book by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="System.IndexOutOfRangeException">Throw if index out of range</exception>
        Book Remove(int id);
    }
}
