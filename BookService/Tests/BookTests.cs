using Logic;
using Logic.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Class for testing Authors
    /// </summary>
    public class BookTests
    {
        /// <summary>
        /// Test for GetBookById-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_GetBookByIndex_Exception(int id)
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.GetBookById(id));
        }

        /// <summary>
        /// Test for AddBook-method
        /// </summary>
        [Fact]
        public void Library_AddBook_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book() { Id = 12, Name = "Book12" };

            // Act
            library.AddBook(newBook);
            books.Add(newBook);

            // Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for GetBookById-method
        /// </summary>
        [Fact]
        public void Library_GetBookByIndex_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Book book = library.GetBookById(1);

            // Assert
            Assert.Equal(books[0], book);
        }

        /// <summary>
        /// Test for SetBookById-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_SetBookByIndex_Exception(int id)
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.SetBookById(newBook, id));
        }

        /// <summary>
        /// Test for SetBookById-method
        /// </summary>
        [Fact]
        public void Library_SetBookByIndex_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book() { Id = 12, Name = "Book12" };

            // Act
            library.SetBookById(newBook, 1);
            books[0] = newBook;

            // Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for RemoveBook-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_RemoveBook_Exception(int id)
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.RemoveBook(id));
        }

        /// <summary>
        /// Test for RemoveBook-method
        /// </summary>
        [Fact]
        public void Library_RemoveBook_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            library.RemoveBook(1);
            books.RemoveAt(0);

            // Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for UpdateAuthor-method
        /// </summary>
        [Fact]
        public void Library_UpdateAuthor_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };
            List<BookAuthor> bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 3 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 2 },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksAuthors()).Returns(bookAuthors);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            bookAuthors.Add(new BookAuthor() { BookIndex = 0, AuthorIndex = 2 });
            library.UpdateAuthor(2, 0);

            // Assert
            Assert.Equal(bookAuthors, library.GetBookAuthors());
        }

        /// <summary>
        /// Test for UpdateGenre-method
        /// </summary>
        [Fact]
        public void Library_UpdateGenre_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };
            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 3 },
                new BookGenre() { BookIndex = 2, GenreIndex = 2 }
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            bookGenres.Add(new BookGenre() { BookIndex = 0, GenreIndex = 2 });
            library.UpdateGenre(2, 0);

            // Assert
            Assert.Equal(bookGenres, library.GetBookGenres());
        }

        /// <summary>
        /// Test for SearchByGenre-method
        /// </summary>
        [Fact]
        public void Library_SearchByGenre_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };
            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 3 },
                new BookGenre() { BookIndex = 2, GenreIndex = 2 }
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            var expectedBooks = bookGenres.Where(item => item.GenreIndex == 0)
                                          .Select(item => books[item.BookIndex]);
            IEnumerable<Book> actualBooks = library.SearchByGenre(0);

            // Assert
            Assert.Equal(expectedBooks, actualBooks);
        }

        /// <summary>
        /// Test for SearchByGenre-method
        /// </summary>
        [Fact]
        public void Library_SearchByAuthor_Correct()
        {
            // Arrange
            List<Book> books = new List<Book>()
            {
                new Book() { Id = 1, Name = "Book0" },
                new Book() { Id = 2, Name = "Book1" },
            };
            List<BookAuthor> bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 3 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 2 },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksAuthors()).Returns(bookAuthors);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            IEnumerable<Book> expectedBooks = bookAuthors.Where(item => item.AuthorIndex == 0)
                                                        .Select(item => books[item.BookIndex]);
            IEnumerable<Book> actualBooks = library.SearchByAuthor(0);

            // Assert
            Assert.Equal(expectedBooks, actualBooks);
        }
    }
}
