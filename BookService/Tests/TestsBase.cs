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
        /// <returns>Configured mock</returns>
        protected Mock<IDataProvider> SetMock()
        {
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);

            return data;
        }
    }
}
