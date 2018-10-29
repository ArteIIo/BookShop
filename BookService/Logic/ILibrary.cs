using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Interface of the book's collecton
    /// </summary>
    public interface ILibrary
    {

        /// <summary>
        /// Gets size of the book's collection
        /// </summary>
        int BooksCount { get; }

        /// <summary>
        /// Gets size of the authors's collection
        /// </summary>
        int AuthorsCount { get; }

        /*=======================Methods for author's part=======================*/

        /// <summary>
        /// Get author value by it's index
        /// </summary>
        /// <param name="id">Index of the selected author</param>
        /// <returns>author by selected index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        Author GetAuthorByIndex(int id);

        /// <summary>
        /// Return collection of authors
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Set author value by it's index
        /// </summary>
        /// <param name="author">New author</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="IndexOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        void SetAuthorByIndex(Author author, int id);

        /// <summary>
        /// Remove author by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if index out of range</exception>
        Author RemoveAuthor(int id);

        /// <summary>
        /// Add author to collection
        /// </summary>
        /// <param name="author">New author</param>
        void AddAuthor(Author author);
        /*=======================Methods for book's part=======================*/

        /// <summary>
        /// Get book value by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Book by selected index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        Book GetBookByIndex(int id);

        /// <summary>
        /// Return collection of books
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Set book value by it's index
        /// </summary>
        /// <param name="book">New book</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="ArgumentOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        void SetBookByIndex(Book book, int id);

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book">New book</param>
        void AddBook(Book book);

        /// <summary>
        /// Remove book by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if index out of range</exception>
        Book RemoveBook(int id);

        /// <summary>
        /// Method which update author reference of the selected book
        /// </summary>
        /// <param name="authorId">Author's index</param>
        /// <param name="bookId">Book's index</param>
        void UpdateAuthor(int authorId, int bookId);

        /// <summary>
        /// Method which update genre reference of the selected book
        /// </summary>
        /// <param name="genreId">Genre's index</param>
        /// <param name="bookId">Book's index</param>
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

        /*=======================Methods for genre's part=========================*/

        /// <summary>
        /// Get genre value by it's index
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>genre by selected index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        Genre GetGenreByIndex(int id);

        /// <summary>
        /// Return collection of genres
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Genre> GetGenres();

        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="newGenre">New genre</param>
        void AddGenre(Genre newGenre);

        /// <summary>
        /// Remove genre by it's index
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>Deleted Gender</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if index out of range</exception>
        Genre RemoveGenre(int id);

        /*==========================ExtraMethods for testing=============================*/

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
