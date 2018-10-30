using Logic;
using Logic.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    /// <summary>
    /// Class with base functional for unit tests
    /// </summary>
    public class TestsBase
    {
        /// <summary>
        /// List of authors
        /// </summary>
        protected List<Author> authors;

        /// <summary>
        /// List of books
        /// </summary>
        protected List<Book> books;

        /// <summary>
        /// List of genres
        /// </summary>
        protected List<Genre> genres;

        /// <summary>
        /// List of Book-Authors pairs
        /// </summary>
        protected List<BookAuthor> bookAuthors;

        /// <summary>
        /// List of Book-Genre Pairs
        /// </summary>
        protected List<BookGenre> bookGenres;

        /// <summary>
        /// Method for lists initialisation
        /// </summary>
        protected void InitLists()
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
                new BookAuthor() { BookIndex = 0, AuthorIndex = 0 },
                new BookAuthor() { BookIndex = 0, AuthorIndex = 1 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
            };
            bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 0, GenreIndex = 0 },
                new BookGenre() { BookIndex = 0, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 1, GenreIndex = 1 }
            };
        }

        /// <summary>
        /// Method for mock config
        /// </summary>
        /// <returns>Configured mock</returns>
        protected Mock<IDataProvider> SetMock()
        {
            Mock<IDataProvider> data = new Mock<IDataProvider>();

            data.Setup(p => p.GetAuthors()).Returns(authors);

            data.Setup(p => p.GetBooks()).Returns(books);

            data.Setup(p => p.GetGenres()).Returns(genres);

            data.Setup(p => p.GetBooksAuthors()).Returns(bookAuthors);

            data.Setup(p => p.GetBooksGenres()).Returns(bookGenres);

            return data;
        }
    }
}
