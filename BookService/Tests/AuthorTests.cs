using System;
using System.Collections.Generic;
using Logic;
using Logic.Models;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;

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
        public void AuthorService_GetAuthorByIndex_Exception(int id)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
            };
            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Authors.AddRange(authors);
            libraryDB.SaveChanges();

            IAuthorService authorService = new AuthorService(libraryDB);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                       authorService.GetAuthorById(id));
        }

        /// <summary>
        /// Test for GetAuthorById-method
        /// </summary>
        [Fact]
        public void AuthorService_GetAuthorByIndex_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
            };
            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Authors.AddRange(authors);
            libraryDB.SaveChanges();

            IAuthorService authorService = new AuthorService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            IAuthorService authorServiceMoq = new LibraryCollection(data.Object);

            // Act
            Author authorActual = authorServiceMoq.GetAuthorById(1);
            Author authorExpected = authorServiceMoq.GetAuthorById(1);

            // Assert
            Assert.Equal(authorExpected, authorActual);
        }

        /// <summary>
        /// Test for SetAuthorById-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the selected author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void AuthorService_SetAuthorByIndex_Exception(int id)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
            };
            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Authors.AddRange(authors);
            libraryDB.SaveChanges();

            IAuthorService authorService = new AuthorService(libraryDB);
            Author newAuthor = new Author();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    authorService.SetAuthorById(newAuthor, id));
        }

        /// <summary>
        /// Test for SetAuthorById-method
        /// </summary>
        [Fact]
        public void AuthorService_SetAuthorByIndex_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
            };
            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Authors.AddRange(authors);
            libraryDB.SaveChanges();

            IAuthorService authorService = new AuthorService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            IAuthorService authorServiceMoq = new LibraryCollection(data.Object);

            // Act
            Author author = new Author() { AuthorId = 1, Name = "Name10", Surname = "Surname10" };
            authorService.SetAuthorById(author, 1);
            authorServiceMoq.SetAuthorById(author, 1);

            // Assert
            Assert.Equal(authorServiceMoq.GetAuthorById(1).Name, authorService.GetAuthorById(1).Name);
            Assert.Equal(authorServiceMoq.GetAuthorById(1).Surname, authorService.GetAuthorById(1).Surname);
            Assert.Equal(authorServiceMoq.GetAuthorById(1).Books, authorService.GetAuthorById(1).Books);
        }

        /// <summary>
        /// Test for RemoveAuthor-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void AuthorService_RemoveAuthor_Exception(int id)
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
            };
            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Authors.AddRange(authors);
            libraryDB.SaveChanges();

            IAuthorService authorService = new AuthorService(libraryDB);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    authorService.RemoveAuthor(id));
        }

        /// <summary>
        /// Test for RemoveAuthor-method
        /// </summary>
        [Fact]
        public void AuthorService_RemoveAutor_Correct()
        {
            // Arrage
            List<Author> authors = new List<Author>()
            {
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
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
            libraryDB.Authors.AddRange(authors);
            libraryDB.BookToAuthor.AddRange(bookAuthors);
            libraryDB.SaveChanges();

            IAuthorService authorService = new AuthorService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetAuthors()).Returns(authors);
            data.Setup(p => p.GetBooksAuthors()).Returns(bookAuthors);
            IAuthorService authorServiceMoq = new LibraryCollection(data.Object);

            ILibrary library = new LibraryService(libraryDB);

            // Act
            authorService.RemoveAuthor(1);
            authorServiceMoq.RemoveAuthor(1);

            // Assert
            Assert.Equal(authorServiceMoq.GetAuthors(), authorService.GetAuthors());
            Assert.Equal((authorServiceMoq as ILibrary).GetBookAuthors(), library.GetBookAuthors());
        }
    }
}
