using Logic;
using Logic.Models;
using Microsoft.EntityFrameworkCore;
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
                new Genre() { GenreId = 1, Name = "Genre0" },
                new Genre() { GenreId = 2, Name = "Genre1" },
                new Genre() { GenreId = 3, Name = "Genre2" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Genres.AddRange(genres);
            libraryDB.SaveChanges();

            IGenreService genreService = new GenreService(libraryDB);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    genreService.GetGenreById(id));
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
                new Genre() { GenreId = 1, Name = "Genre0" },
                new Genre() { GenreId = 2, Name = "Genre1" },
                new Genre() { GenreId = 3, Name = "Genre2" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Genres.AddRange(genres);
            libraryDB.SaveChanges();

            IGenreService genreService = new GenreService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);

            IGenreService genreServiceMoq = new LibraryCollection(data.Object);

            // Act
            Genre genreExpected = genreServiceMoq.GetGenreById(1);
            Genre genreActual = genreService.GetGenreById(1);

            // Assert
            Assert.Equal(genreExpected, genreActual);
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
                new Genre() { GenreId = 1, Name = "Genre0" },
                new Genre() { GenreId = 2, Name = "Genre1" },
                new Genre() { GenreId = 3, Name = "Genre2" },
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Genres.AddRange(genres);
            libraryDB.SaveChanges();

            IGenreService genreService = new GenreService(libraryDB);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                                                    genreService.RemoveGenre(id));
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
                new Genre() { GenreId = 1, Name = "Genre0" },
                new Genre() { GenreId = 2, Name = "Genre1" },
                new Genre() { GenreId = 3, Name = "Genre2" },
            };
            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 2 }
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Genres.AddRange(genres);
            libraryDB.BookToGenre.AddRange(bookGenres);
            libraryDB.SaveChanges();

            IGenreService genreService = new GenreService(libraryDB);

            Mock<IDataProvider> data = new Mock<IDataProvider>();
            data.Setup(p => p.GetGenres()).Returns(genres);
            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            IGenreService genreServiceMoq = new LibraryCollection(data.Object);

            // Act
            genreService.RemoveGenre(3);
            genreServiceMoq.RemoveGenre(3);

            // Assert
            Assert.Equal(genreServiceMoq.GetGenres(), genreService.GetGenres());
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
                new Genre() { GenreId = 1, Name = "Genre0" },
                new Genre() { GenreId = 2, Name = "Genre1" },
                new Genre() { GenreId = 3, Name = "Genre2" },
            };

            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 2 }
            };

            var options = new DbContextOptionsBuilder<LibraryDBContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;

            LibraryDBContext libraryDB = new LibraryDBContext(options);
            libraryDB.Genres.AddRange(genres);
            libraryDB.BookToGenre.AddRange(bookGenres);
            libraryDB.SaveChanges();

            IGenreService genreService = new GenreService(libraryDB);

            // Act
            Genre actual = genreService.RemoveGenre(1);

            // Assert
            Assert.Null(actual);
        }
    }
}
