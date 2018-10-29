using Logic;
using Logic.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class GenreTests
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
        /// Test for GetGenreByIndex-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the genre</param>
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
                                                    library.GetGenreByIndex(index));
        }

        /// <summary>
        /// Test for GetGenreByIndex-method
        /// </summary>
        [Fact]
        public void Library_GetAuthorByIndex()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Genre genre = library.GetGenreByIndex(0);

            // Assert
            Assert.Equal(genre, genres[0]);
        }

        /// <summary>
        /// Test for RemoveGenre-method(Expected: exception)
        /// </summary>
        /// <param name="index">Index of the genre</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_RemoveGenre_Exception(int index)
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.RemoveGenre(index));
        }

        /// <summary>
        /// Test for RemoveGenre-method
        /// </summary>
        [Fact]
        public void Library_RemoveGenre()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            genres.RemoveAt(3);
            library.RemoveGenre(3);

            // Assert
            Assert.Equal(genres, library.GetGenres());
            Assert.Equal(bookGenres, library.GetBookGenres());
        }

        /// <summary>
        /// Test for RemoveGenre-method when some book has this genre
        /// </summary>
        [Fact]
        public void Library_RemoveGenre_NULL()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Genre actual = library.RemoveGenre(0);

            // Assert
            Assert.Null(actual);
            Assert.Equal(bookGenres, library.GetBookGenres());
        }

        /// <summary>
        /// Test for AddGenre-method
        /// </summary>
        [Fact]
        public void Library_AddAuthor()
        {
            // Arrage
            InitLists();
            Mock<IDataProvider> data = SetMock();
            ILibrary library = new LibraryCollection(data.Object);
            Genre newGenre = new Genre() { Id = 0, Name = "Genre10" };

            // Act
            genres.Add(newGenre);
            library.AddGenre(newGenre);

            // Assert
            Assert.Equal(genres, library.GetGenres());
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
                new Genre() { Id = 3, Name = "Genre3" },
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
