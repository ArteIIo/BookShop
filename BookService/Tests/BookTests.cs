using Logic;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.SaveChanges();

            IBookService bookService = new BookService(libraryDB);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    bookService.GetBookById(id));
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.SaveChanges();

            IBookService bookService = new BookService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            IBookService bookServiceMoq = new LibraryCollection(data.Object);

            // Act
            Book bookExpected = bookServiceMoq.GetBookById(1);
            Book bookActual = bookService.GetBookById(1);

            // Assert
            Assert.Equal(bookExpected, bookActual);
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.SaveChanges();

            IBookService bookService = new BookService(libraryDB);
            Book newBook = new Book();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                        bookService.SetBookById(newBook, id));
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.SaveChanges();

            IBookService bookService = new BookService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            IBookService bookServiceMoq = new LibraryCollection(data.Object);
            Book newBook = new Book() { BookId = 1, Name = "Book12" };

            // Act
            bookService.SetBookById(newBook, 1);
            bookServiceMoq.SetBookById(newBook, 1);

            // Assert
            Assert.Equal(bookServiceMoq.GetBookById(1).Name, bookService.GetBookById(1).Name);
            Assert.Equal(bookServiceMoq.GetBookById(1).AuthorsList, bookService.GetBookById(1).AuthorsList);
            Assert.Equal(bookServiceMoq.GetBookById(1).GenresList, bookService.GetBookById(1).GenresList);
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.SaveChanges();

            IBookService bookService = new BookService(libraryDB);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                        bookService.RemoveBook(id));
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.SaveChanges();

            IBookService bookService = new BookService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);

            IBookService bookServiceMoq = new LibraryCollection(data.Object);

            // Act
            bookServiceMoq.RemoveBook(1);
            bookService.RemoveBook(1);

            // Assert
            Assert.Equal(bookServiceMoq.GetBooks(), bookService.GetBooks());
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };
            List<BookAuthor> bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.BookToAuthor.AddRange(bookAuthors);
            libraryDB.SaveChanges();

            ILibrary bookService = new LibraryService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksAuthors()).Returns(bookAuthors);

            ILibrary bookServiceMoq = new LibraryCollection(data.Object);

            // Act
            bookServiceMoq.UpdateAuthor(2, 1);
            bookService.UpdateAuthor(2, 1);

            // Assert
            Assert.Equal(bookServiceMoq.GetBookAuthors(), bookService.GetBookAuthors());
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };
            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 3 },
                new BookGenre() { BookIndex = 2, GenreIndex = 2 }
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.BookToGenre.AddRange(bookGenres);
            libraryDB.SaveChanges();

            ILibrary bookService = new LibraryService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            ILibrary bookServiceMoq = new LibraryCollection(data.Object);

            // Act
            bookService.UpdateGenre(2, 1);
            bookServiceMoq.UpdateGenre(2, 1);

            // Assert
            Assert.Equal(bookServiceMoq.GetBookGenres(), bookService.GetBookGenres());
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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };
            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 3 },
                new BookGenre() { BookIndex = 2, GenreIndex = 2 }
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.BookToGenre.AddRange(bookGenres);
            libraryDB.SaveChanges();

            ILibrary bookService = new LibraryService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            ILibrary bookServiceMoq = new LibraryCollection(data.Object);

            // Act
            var expectedBooks = bookServiceMoq.SearchByGenre(1);
            var actualBooks = bookService.SearchByGenre(1);

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
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" },
            };
            List<BookAuthor> bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 3 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 2 },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Books.AddRange(books);
            libraryDB.BookToAuthor.AddRange(bookAuthors);
            libraryDB.SaveChanges();

            ILibrary bookService = new LibraryService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetBooks()).Returns(books);
            data.Setup(p => p.GetBooksAuthors()).Returns(bookAuthors);

            ILibrary bookServiceMoq = new LibraryCollection(data.Object);

            // Act
            IEnumerable<Book> expectedBooks = bookServiceMoq.SearchByAuthor(1);
            IEnumerable<Book> actualBooks = bookService.SearchByAuthor(1);

            // Assert
            Assert.Equal(expectedBooks, actualBooks);
        }
    }
}
