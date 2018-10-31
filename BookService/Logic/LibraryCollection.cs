using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Class-realization of the book's collection
    /// </summary>
    public class LibraryCollection : ILibrary
    {
        /// <summary>
        /// List with books
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// List with authors
        /// </summary>
        private List<Author> authors;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryCollection"/> class.
        /// </summary>
        public LibraryCollection(IDataProvider data)
        {
            authors = new List<Author>(data.GetAuthors());
            books = new List<Book>(data.GetBooks());
        }

        /// <summary>
        /// Get auhtor value by it's index
        /// </summary>
        /// <param name="id">Index of the selected auhtor</param>
        /// <returns>Auhtor by selected index</returns>
        /// <exception cref="IndexOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        public Author GetAuthorByIndex(int id)
        {
            Author author = authors.Find(authors => authors.Id == id);
            if (author == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return author;
        }

        /// <summary>
        /// Get book value by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>author by selected index</returns>
        /// <exception cref="IndexOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        public Book GetBookByIndex(int id)
        {
            Book book = books.Find(item => item.Id == id);
            if (book == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return book;
        }

        /// <summary>
        /// Set author value by it's index
        /// </summary>
        /// <param name="newAuthor">New author</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="IndexOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        public void SetAuthorByIndex(Author newAuthor, int id)
        {
            Author author = authors.Find(item => item.Id == id);

            authors[authors.IndexOf(author)] = newAuthor;
        }

        /// <summary>
        /// Set book value by it's index
        /// </summary>
        /// <param name="newBook">New book</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="IndexOutOfRangeException">Throw when index out of
        /// list's count range</exception>
        public void SetBookByIndex(Book newBook, int id)
        {
            Book book = books.Find(item => item.Id == id);

            books[books.IndexOf(book)] = newBook;
        }

        /// <summary>
        /// Gets size of the collection
        /// </summary>
        public int BooksCount
        {
            get { return books.Count; }
        }

        /// <summary>
        /// Gets size of the authors's collection
        /// </summary>
        public int AuthorsCount
        {
            get { return authors.Count; }
        }

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book">New book</param>
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        /// <summary>
        /// Return collection of books
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        /// <summary>
        /// Remove book by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Throw if index out of range</exception>
        public Book RemoveBook(int id)
        {
            Book deleted = books.Find(item => item.Id == id);
            if (deleted == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            books.Remove(deleted);

            return deleted;
        }

        /// <summary>
        /// Return collection of authors
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }

        /// <summary>
        /// Remove author by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if index out of range</exception>
        public Author RemoveAuthor(int id)
        {
            Author author = authors.Find(item => item.Id == id);
            if (author == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            books.RemoveAll(item => item.Author == author);
            authors.RemoveAt(id);

            return author;
        }

        /// <summary>
        /// Method which update author reference of the selected book
        /// </summary>
        /// <param name="authorId">Author's index</param>
        /// <param name="bookId">Book's index</param>
        /// <exception cref="IndexOutOfRangeException">Throw when ether author's index
        /// or book's index out of range of their collection's count</exception>
        public void UpdateAuthor(int authorId, int bookId)
        {
            books[bookId].Author = authors[authorId];
        }

        /// <summary>
        /// Add author to collection
        /// </summary>
        /// <param name="author">New author</param>
        public void AddAuthor(Author author)
        {
            authors.Add(author);
        }
    }
}
