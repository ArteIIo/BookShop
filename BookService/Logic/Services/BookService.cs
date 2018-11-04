using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Models;

namespace Logic
{
    /// <summary>
    /// Realization the book service
    /// </summary>
    public class BookService : IBookService
    {
        /// <summary>
        /// DB context
        /// </summary>
        private LibraryDBContext dBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="dBContext">DB context</param>
        public BookService(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book">New book</param>
        public void AddBook(Book book)
        {
            dBContext.Books.Add(book);
            dBContext.SaveChanges();
        }

        /// <summary>
        /// Get author value by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>author by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public Book GetBookById(int id)
        {
            try
            {
                Book book = dBContext.Books.First(item => item.BookId == id);

                return book;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }

        /// <summary>
        /// Return collection of books
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Book> GetBooks()
        {
            return dBContext.Books;
        }

        /// <summary>
        /// Remove book by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="System.IndexOutOfRangeException">Throw if id out of range</exception>
        public Book RemoveBook(int id)
        {
            try
            {
                Book deleted = dBContext.Books.First(item => item.BookId == id);
                dBContext.Books.Remove(deleted);
                dBContext.SaveChanges();

                return deleted;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }

        /// <summary>
        /// Set book value by it's id
        /// </summary>
        /// <param name="book">New book</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="IndexOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public void SetBookById(Book book, int id)
        {
            try
            {
                Book currBook = dBContext.Books.First(item => item.BookId == id);
                currBook.Name = book.Name;
                currBook.AuthorsList = book.AuthorsList;
                currBook.GenresList = book.GenresList;
                dBContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }
    }
}
