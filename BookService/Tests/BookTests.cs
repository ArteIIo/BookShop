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
        /// List of authors
        /// </summary>
        private static List<Author> authors;

        /// <summary>
        /// List of books
        /// </summary>
        private static List<Book> books;

        /// <summary>
        /// List of genres
        /// </summary>
        private static List<Genre> genres;

        /// <summary>
        /// List of Book-Authors pairs
        /// </summary>
        private static List<BookAuthor> bookAuthors;

        /// <summary>
        /// List of Book-Genre Pairs
        /// </summary>
        private static List<BookGenre> bookGenres;

        /// <summary>
        /// Test for GetBookByIndex-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the selected book</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_GetBookByIndex_Exception(int index)
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                                                    library.GetBookByIndex(index));
        }

        /// <summary>
        /// Test for AddBook-method
        /// </summary>
        [Fact]
        public void Library_AddBook()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book() { Id = 12, Name = "Book12", Authors = bookAuthors, Genres = bookGenres };

            // Act
            library.AddBook(newBook);
            books.Add(newBook);

            // Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for GetBookByIndex-method
        /// </summary>
        [Fact]
        public void Library_GetBookByIndex()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Book book = library.GetBookByIndex(0);

            // Assert
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
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.SetBookByIndex(newBook, index));
        }

        /// <summary>
        /// Test for SetBookByIndex-method
        /// </summary>
        [Fact]
        public void Library_SetBookByIndex()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);
            Book newBook = new Book() { Id = 12, Name = "Book12", Authors = bookAuthors, Genres = bookGenres };

            // Act
            library.SetBookByIndex(newBook, 0);
            books[0] = newBook;

            // Assert
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
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.RemoveBook(index));
        }

        /// <summary>
        /// Test for RemoveBook-method
        /// </summary>
        [Fact]
        public void Library_RemoveBook()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            library.RemoveBook(0);
            books.RemoveAt(0);

            // Assert
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for UpdateAuthor-method
        /// </summary>
        [Fact]
        public void Library_UpdateAuthor()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            bookAuthors.Add(new BookAuthor() { Book = books[0], Author = authors[2] });
            library.UpdateAuthor(2, 0);

            // Assert
            Assert.Equal(bookAuthors, library.GetBookAuthors());
        }

        /// <summary>
        /// Test for UpdateGenre-method
        /// </summary>
        [Fact]
        public void Library_UpdateGenre()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            bookGenres.Add(new BookGenre() { Book = books[0], Genre = genres[2] });
            library.UpdateGenre(2, 0);

            // Assert
            Assert.Equal(bookGenres, library.GetBookGenres());
        }

        /// <summary>
        /// Test for SearchByGenre-method
        /// </summary>
        [Fact]
        public void Library_SearchByGenre()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            IEnumerable<Book> expectedBooks = from item in bookGenres
                                      where item.Genre == genres[0]
                                      select item.Book;
            IEnumerable<Book> actualBooks = library.SearchByGenre(0);

            // Assert
            Assert.Equal(expectedBooks, actualBooks);
        }

        /// <summary>
        /// Test for SearchByGenre-method
        /// </summary>
        [Fact]
        public void Library_SearchByAuthor()
        {
            // Arrange
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            IEnumerable<Book> expectedBooks = from item in bookAuthors
                                              where item.Author == authors[0]
                                              select item.Book;
            IEnumerable<Book> actualBooks = library.SearchByAuthor(0);

            // Assert
            Assert.Equal(expectedBooks, actualBooks);
        }

        /// <summary>
        /// Method for lists initialisation
        /// </summary>
        private static void InitLists()
        {
            authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 1, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 2, Name = "Name2", Surname = "Surname2" },
            };
            books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0" },
                new Book() { Id = 1, Name = "Book1" },
            };
            genres = new List<Genre>()
            {
                new Genre() { Id = 0, Name = "Genre0" },
                new Genre() { Id = 1, Name = "Genre1" },
                new Genre() { Id = 2, Name = "Genre2" },
            };
            bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { Book = books[0], Author = authors[0] },
                new BookAuthor() { Book = books[0], Author = authors[1] },
                new BookAuthor() { Book = books[1], Author = authors[2] },
                new BookAuthor() { Book = books[1], Author = authors[1] },
            };
            bookGenres = new List<BookGenre>()
            {
                new BookGenre() { Book = books[0], Genre = genres[0] },
                new BookGenre() { Book = books[0], Genre = genres[1] },
                new BookGenre() { Book = books[1], Genre = genres[2] },
                new BookGenre() { Book = books[1], Genre = genres[1] }
            };
        }

        /// <summary>
        /// Method for mock config
        /// </summary>
        /// <returns>Configured mock</returns>
        private Mock<IDataProvider> SetMock()
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
            data.Setup(p => p.SetGenres(It.IsAny<List<Genre>>()))
                .Callback((List<Genre> items) =>
                {
                    items.AddRange(genres);
                });
            data.Setup(p => p.SetBooksAuthors(It.IsAny<List<BookAuthor>>()))
                .Callback((List<BookAuthor> items) =>
                {
                    items.AddRange(bookAuthors);
                });
            data.Setup(p => p.SetBooksGenres(It.IsAny<List<BookGenre>>()))
                .Callback((List<BookGenre> items) =>
                {
                    items.AddRange(bookGenres);
                });

            return data;
        }
    }
}
