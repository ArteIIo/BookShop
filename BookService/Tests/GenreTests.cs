using Logic;
using Logic.Models;
using Moq;
using System;
using Xunit;

namespace Tests
{
    public class GenreTests : TestsBase
    {
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
            genres.Add(new Genre() { Id = 3, Name = "Genre3" });
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
    }
}
