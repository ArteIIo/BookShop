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
        /// Test for GetGenreById-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the genre</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_GetGenreByIndex_Exception(int id)
        {
            // Arrage
            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Genre0" },
                new Genre() { Id = 2, Name = "Genre1" },
                new Genre() { Id = 3, Name = "Genre2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.GetGenreById(id));
        }

        /// <summary>
        /// Test for GetGenreById-method
        /// </summary>
        [Fact]
        public void Library_GetGenreByIndex_Correct()
        {
            // Arrage
            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Genre0" },
                new Genre() { Id = 2, Name = "Genre1" },
                new Genre() { Id = 3, Name = "Genre2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Genre genre = library.GetGenreById(1);

            // Assert
            Assert.Equal(genre, genres[0]);
        }

        /// <summary>
        /// Test for RemoveGenre-method(Expected: exception)
        /// </summary>
        /// <param name="id">Index of the genre</param>
        [Theory]
        [InlineData(-1)]
        [InlineData(100)]
        public void Library_RemoveGenre_Exception(int id)
        {
            // Arrage
            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Genre0" },
                new Genre() { Id = 2, Name = "Genre1" },
                new Genre() { Id = 3, Name = "Genre2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    library.RemoveGenre(id));
        }

        /// <summary>
        /// Test for RemoveGenre-method
        /// </summary>
        [Fact]
        public void Library_RemoveGenre_Correct()
        {
            // Arrage
            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Genre0" },
                new Genre() { Id = 2, Name = "Genre1" },
                new Genre() { Id = 3, Name = "Genre2" },
            };
            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 2 }
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);
            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            genres.RemoveAt(2);
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
            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Genre0" },
                new Genre() { Id = 2, Name = "Genre1" },
                new Genre() { Id = 3, Name = "Genre2" },
            };
            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 3 },
                new BookGenre() { BookIndex = 2, GenreIndex = 1 }
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);
            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            ILibrary library = new LibraryCollection(data.Object);

            // Act
            Genre actual = library.RemoveGenre(1);

            // Assert
            Assert.Null(actual);
            Assert.Equal(bookGenres, library.GetBookGenres());
        }

        /// <summary>
        /// Test for AddGenre-method
        /// </summary>
        [Fact]
        public void Library_AddGenre_Correct()
        {
            // Arrage
            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = 1, Name = "Genre0" },
                new Genre() { Id = 2, Name = "Genre1" },
                new Genre() { Id = 3, Name = "Genre2" },
            };

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);

            ILibrary library = new LibraryCollection(data.Object);
            Genre newGenre = new Genre() { Id = 0, Name = "Genre10" };

            // Act
            genres.Add(newGenre);
            library.AddGenre(newGenre);

            // Assert
            Assert.Equal(genres, library.GetGenres());
        }
    }
}
