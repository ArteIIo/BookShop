using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Interface of the library's service
    /// </summary>
    public interface ILibrary
    {
        /// <summary>
        /// Method which update author reference of the selected book
        /// </summary>
        /// <param name="authorId">Author's id</param>
        /// <param name="bookId">Book's id</param>
        void UpdateAuthor(int authorId, int bookId);

        /// <summary>
        /// Method which update genre reference of the selected book
        /// </summary>
        /// <param name="genreId">Genre's id</param>
        /// <param name="bookId">Book's id</param>
        void UpdateGenre(int genreId, int bookId);

        /// <summary>
        /// Search books by it's genre
        /// </summary>
        /// <param name="genreIndex">Index of the genre</param>
        /// <returns>Collection of books</returns>
        IEnumerable<Book> SearchByGenre(int genreIndex);

        /// <summary>
        /// Search books by it's author
        /// </summary>
        /// <param name="authorIndex">Index of the genre</param>
        /// <returns>Collection of books</returns>
        IEnumerable<Book> SearchByAuthor(int authorIndex);

        /// <summary>
        /// Get List of pairs Book-Author
        /// </summary>
        /// <returns>List of pairs Book-Author</returns>
        IEnumerable<BookAuthor> GetBookAuthors();

        /// <summary>
        /// Get List of pairs Book-Genre
        /// </summary>
        /// <returns>List of pairs Book-Genre</returns>
        IEnumerable<BookGenre> GetBookGenres();
    }
}
