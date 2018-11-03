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
        /// Test for GetAuthorById-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_GetAuthorByIndex_Exception(int id)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 3, Name = "Name2", Surname = "Surname2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.GetAuthorById(id));
        }

        /// <summary>
        /// Test for GetAuthorById-method
        /// </summary>
        [Fact]
        public void Library_GetAuthorByIndex_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 3, Name = "Name2", Surname = "Surname2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Author author = library.GetAuthorById(1);

            // Assert
            Assert.Equal(author, authors[0]);
        }

        /// <summary>
        /// Test for SetAuthorById-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the selected author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_SetAuthorByIndex_Exception(int id)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 3, Name = "Name2", Surname = "Surname2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            ILibrary library = new LibraryCollection(data.Object);
            Author newAuthor = new Author();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.SetAuthorById(newAuthor, id));
        }

        /// <summary>
        /// Test for SetAuthorById-method
        /// </summary>
        [Fact]
        public void Library_SetAuthorByIndex_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 3, Name = "Name2", Surname = "Surname2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Author author = new Author() { Id = 1, Name = "Name10", Surname = "Surname10" };
            authors[0] = author;
            library.SetAuthorById(author, 1);

            // Assert
            Assert.Equal(author, library.GetAuthorById(1));
        }

        /// <summary>
        /// Test for RemoveAuthor-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_RemoveAuthor_Exception(int id)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { Id = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 3, Name = "Name2", Surname = "Surname2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.RemoveAuthor(id));
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
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 1, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 2, Name = "Name2", Surname = "Surname2" },
            };

            List<BookAuthor> bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { BookIndex = 0, AuthorIndex = 0 },
                new BookAuthor() { BookIndex = 0, AuthorIndex = 1 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            data.Setup(p => p.GetBooksAuthors()).Returns(bookAuthors);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            bookAuthors.RemoveAll(item => item.AuthorIndex == 0);
            authors.RemoveAt(0);
            library.RemoveAuthor(0);

            // Assert
            Assert.Equal(authors, library.GetAuthors());
            Assert.Equal(bookAuthors, library.GetBookAuthors());
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
                new Author() { Id = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 3, Name = "Name2", Surname = "Surname2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);

            ILibrary library = new LibraryCollection(data.Object);
            Author newAuthor = new Author() { Id = 20, Name = "Name10", Surname = "Surname10" };

            // Act
            authors.Add(newAuthor);
            library.AddAuthor(newAuthor);

            // Assert
            Assert.Equal(authors, library.GetAuthors());
        }
    }
}
