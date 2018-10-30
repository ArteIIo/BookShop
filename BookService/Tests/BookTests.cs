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
    public class BookTests : TestsBase
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
    }
}
