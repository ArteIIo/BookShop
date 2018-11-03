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
      
        /// <summary>
        /// Gets size of the genre's collection
        /// </summary>
        int GenresCount { get; }

        #region Author Methods

        /// <summary>
        /// Get author value by it's id
        /// </summary>
        /// <param name="id">Index of the selected author</param>
        /// <returns>author by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        Author GetAuthorById(int id);

        /// <summary>
        /// Return collection of authors
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Set author value by it's id
        /// </summary>
        /// <param name="author">New author</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="IndexOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        void SetAuthorById(Author author, int id);

        /// <summary>
        /// Remove author by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        Author RemoveAuthor(int id);

        /// <summary>
        /// Add author to collection
        /// </summary>
        /// <param name="author">New author</param>
        void AddAuthor(Author author);

        #endregion

        #region Book Methods

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

        #endregion

        #region Genre Methods

        /// <summary>
        /// Get genre value by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>genre by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        Genre GetGenreById(int id);

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
        /// Remove genre by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>Deleted Gender</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        Genre RemoveGenre(int id);

        #endregion

        #region Extra

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

        #endregion
    }
}
