using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Interface of the book's service
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Get book value by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Book by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        Book GetBookById(int id);

        /// <summary>
        /// Return collection of books
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Set book value by it's id
        /// </summary>
        /// <param name="book">New book</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        void SetBookById(Book book, int id);

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book">New book</param>
        void AddBook(Book book);

        /// <summary>
        /// Remove book by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        Book RemoveBook(int id);
    }
}
