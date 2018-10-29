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
        /// Test for GetAuthorByIndex-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the author</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_GetAuthorByIndex_Exception(int index)
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
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
        public void Library_GetAuthorByIndex()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
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
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);
            Author newAuthor = new Author();

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.SetAuthorByIndex(newAuthor, index));
        }

        /// <summary>
        /// Test for SetAuthorByIndex-method
        /// </summary>
        [Fact]
        public void Library_SetAuthorByIndex()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
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
            InitLists();
            Mock<IDataProvider> data = SetMock();
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
        public void Library_RemoveAutor()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            bookAuthors.RemoveAll(item => item.Author == authors[0]);
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
        public void Library_AddAuthor()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);
            Author newAuthor = new Author() { Id = 0, Name = "Name10", Surname = "Surname10" };

            // Act
            authors.Add(newAuthor);
            library.AddAuthor(newAuthor);

            // Assert
            Assert.Equal(authors, library.GetAuthors());
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
