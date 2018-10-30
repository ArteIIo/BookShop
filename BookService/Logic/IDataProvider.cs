using Logic.Models;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Interface for IDataProvider abstruction
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Get book's list
        /// </summary>
        /// <returns>Book's list</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Get author's list
        /// </summary>
        /// <returns>Author's list</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Get genre's list
        /// </summary>
        /// <returns>List of genres</returns>
        IEnumerable<Genre> GetGenres();

        /// <summary>
        /// Set list of Book-Genre pairs
        /// </summary>
        /// <returns>List of Book-Genres pairs</returns>
        IEnumerable<BookGenre> GetBooksGenres();

        /// <summary>
        /// Get list of Book-Genre pairs
        /// </summary>
        /// <returns>List of Book-Author pairs</returns>
        IEnumerable<BookAuthor> GetBooksAuthors();
    }
}
