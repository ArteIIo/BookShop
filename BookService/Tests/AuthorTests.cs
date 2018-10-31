using System;
using System.Collections.Generic;
using Logic;
using Logic.Models;
using Moq;
using Xunit;

namespace Tests
{
    /// <summary>
    /// Class for testing Authors
    /// </summary>
    public class AuthorTests
    {
        /// <summary>
        /// Test for GetAuthorByIndex-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_GetAuthorByIndex_Exception(int index)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.GetAuthorByIndex(index));
        }

        /// <summary>
        /// Test for GetAuthorByIndex-method
        /// </summary>
        [Fact]
        public void Library_GetAuthorByIndex_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Author author = library.GetAuthorByIndex(0);

            // Assert
            Assert.Equal(author, authors[0]);
        }

        /// <summary>
        /// Test for SetAuthorByIndex-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the selected author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_SetAuthorByIndex_Exception(int index)
        {
            // Arrage
            Author newAuthor = new Author();
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.SetAuthorByIndex(newAuthor, index));
        }

        /// <summary>
        /// Test for SetAuthorByIndex-method
        /// </summary>
        [Fact]
        public void Library_SetAuthorByIndex_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Author author = new Author() { Id = 0, Name = "Name10", Surname = "Surname10" };
            library.SetAuthorByIndex(author, 0);

            // Assert
            Assert.Equal(author, library.GetAuthorByIndex(0));
        }

        /// <summary>
        /// Test for RemoveAuthor-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_RemoveAuthor_Exception(int index)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.RemoveAuthor(index));
        }

        /// <summary>
        /// Test for RemoveAuthor-method
        /// </summary>
        [Fact]
        public void Library_RemoveAutor_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            books.RemoveAll(item => item.Author == authors[0]);
            authors.RemoveAt(0);
            library.RemoveAuthor(0);

            // Assert
            Assert.Equal(authors, library.GetAuthors());
            Assert.Equal(books, library.GetBooks());
        }

        /// <summary>
        /// Test for AddAuthor-method
        /// </summary>
        [Fact]
        public void Library_AddAuthor_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" }
            };

            List<Book> books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] }
            };
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);
            ILibrary library = new LibraryCollection(data.Object);
            Author newAuthor = new Author() { Id = 0, Name = "Name10", Surname = "Surname10" };

            // Act
            authors.Add(newAuthor);
            library.AddAuthor(newAuthor);

            // Assert
            Assert.Equal(authors, library.GetAuthors());
        }
    }
}
