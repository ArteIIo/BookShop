using Logic;
using Logic.Models;
using Moq;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Class with base functions for unit tests
    /// </summary>
    public class TestsBase
    {
        /// <summary>
        /// List of authors
        /// </summary>
        protected List<Author> authors;

        /// <summary>
        /// List of Books
        /// </summary>
        protected List<Book> books;

        /// <summary>
        /// Methor for initialising lists
        /// </summary>
        protected void InitLists()
        {
            authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
        }

        /// <summary>
        /// Method for mock config
        /// </summary>
        /// <param name="books">List of books</param>
        /// <param name="authors">List of authors</param>
        /// <returns>Configured mock</returns>
        protected Mock<IDataProvider> SetMock()
        {
            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.SetAuthors(It.IsAny<List<Author>>()))
                .Callback((List<Author> items) =>
                {
                    items.AddRange(authors);
                });
            data.Setup(p => p.SetBooks(It.IsAny<List<Book>>()))
                .Callback((List<Book> items) =>
                {
                    items.AddRange(books);
                });
            ILibrary library = new LibraryCollection(data.Object);

            return data;
        }
    }
}
