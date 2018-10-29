using Logic;
using Logic.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Class for testing Authors
    /// </summary>
    public class BookTests
    {
        /// <summary>
        /// Test for GetBookByIndex-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the selected book</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_GetBookByIndex_Exception(int index)
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                                                    library.GetBookByIndex(index));
        }

        /// <summary>
        /// Test for AddBook-method
        /// </summary>
        [Fact]
        public void Library_AddBook()
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book() { Id = 12, Name = "Book12", Author = authors[0]};

            //Act
            library.AddBook(newBook);
            books.Add(newBook);

            //Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for GetBookByIndex-method
        /// </summary>
        [Fact]
        public void Library_GetBookByIndex()
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);

            //Act
            Book book = library.GetBookByIndex(0);

            //Assert
            Assert.Equal(books[0], book);
        }

        /// <summary>
        /// Test for SetBookByIndex-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the selected book</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_SetBookByIndex_Exception(int index)
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book();

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.SetBookByIndex(newBook, index));
        }

        /// <summary>
        /// Test for SetBookByIndex-method
        /// </summary>
        [Fact]
        public void Library_SetBookByIndex()
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book() { Id = 12, Name = "Book12", Author = authors[0] };

            //Act
            library.SetBookByIndex(newBook, 0);
            books[0] = newBook;

            //Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for RemoveBook-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the selected book</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_RemoveBook_Exception(int index)
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.RemoveBook(index));
        }

        /// <summary>
        /// Test for RemoveBook-method
        /// </summary>
        [Fact]
        public void Library_RemoveBook()
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);

            //Act
            library.RemoveBook(0);
            books.RemoveAt(0);

            //Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for UpdateAuthor-method(Expected: exception)
        /// </summary>
        /// <param name="bookIndex"></param>
        /// <param name="authorIndex"></param>
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        public void Library_UpdateAuthor_Exception(int bookIndex, int authorIndex)
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.UpdateAuthor(authorIndex, bookIndex));
        }

        /// <summary>
        /// Test for UpdateAuthor-method
        /// </summary>
        [Fact]
        public void Library_UpdateAuthor()
        {
            //Arrange
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 1, Name = "Name1", Surname = "Surname1" }
            };
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = SetMock(books, authors);
            ILibrary library = new LibraryCollection(data.Object);

            //Act
            library.UpdateAuthor(1, 0);
            books[0].Author = authors[1];

            //Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Method for mock config
        /// </summary>
        /// <param name="books">List of books</param>
        /// <param name="authors">List of authors</param>
        /// <returns>Configured mock</returns>
        private Mock<IDataProvider> SetMock(List<Book> books, List<Author> authors)
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
