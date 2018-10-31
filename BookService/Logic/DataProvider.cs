using Logic.Models;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Clas for providing data to Service
    /// </summary>
    public class DataProvider : IDataProvider
    {
        /// <summary>
        /// List of books
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// List of authors
        /// </summary>
        private List<Author> authors;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider"/> class.
        /// </summary>
        public DataProvider()
        {
            authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 2, Name = "Name1", Surname = "Surname1" }
            };

            books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0", Author = authors[0] },
                new Book() { Id = 2, Name = "Book1", Author = authors[1] },
                new Book() { Id = 3, Name = "Book2", Author = authors[0] },
                new Book() { Id = 4, Name = "Book3", Author = authors[1] },
            };
        }

        /// <summary>
        /// Get book's list
        /// </summary>
        /// <returns>Book's list</returns>
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        /// <summary>
        /// Get author's list
        /// </summary>
        /// <returns>Author's list</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }
    }
}
