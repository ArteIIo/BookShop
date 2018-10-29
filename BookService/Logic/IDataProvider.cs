using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Interface for IDataProvider abstruction
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Set book's list
        /// </summary>
        /// <param name="books">List of books</param>
        void SetBooks(List<Book> books);

        /// <summary>
        /// Set book's authors
        /// </summary>
        /// <param name="authors">List of authors</param>
        void SetAuthors(List<Author> authors);

        /// <summary>
        /// Set genre's list
        /// </summary>
        /// <param name="genres">List of genres</param>
        void SetGenres(List<Genre> genres);

        /// <summary>
        /// Set list of Book-Genre pairs
        /// </summary>
        /// <param name="bookGenres">List of Book-Genre pairs</param>
        void SetBooksGenres(List<BookGenre> bookGenres);

        /// <summary>
        /// Set list of Book-Author pairs
        /// </summary>
        /// <param name="bookAuthors">List of Book-Author pairs</param>
        void SetBooksAuthors(List<BookAuthor> bookAuthors);
    }
}
