using Logic.Models;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Class for provaide data to service
    /// </summary>
    public class DataProvider : IDataProvider
    {
        /// <summary>
        /// List of books
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// List of authors
        /// </summary>
        private List<Author> authors;

        /// <summary>
        /// List of genres
        /// </summary>
        private List<Genre> genres;

        /// <summary>
        /// List of Book-Author pairs
        /// </summary>
        private List<BookAuthor> bookAuthors;

        /// <summary>
        /// List of Book-Genres pairs
        /// </summary>
        private List<BookGenre> bookGenres;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider"/> class.
        /// </summary>
        public DataProvider()
        {
            authors = new List<Author>()
            {
                new Author() { AuthorId = 1, Name = "Name0", Surname = "Surname0" },
                new Author() { AuthorId = 2, Name = "Name1", Surname = "Surname1" },
                new Author() { AuthorId = 3, Name = "Name2", Surname = "Surname2" },
                new Author() { AuthorId = 4, Name = "Name3", Surname = "Surname3" },
                new Author() { AuthorId = 5, Name = "Name4", Surname = "Surname4" },
            };

            books = new List<Book>()
            {
                new Book() { BookId = 1, Name = "Book0" },
                new Book() { BookId = 2, Name = "Book1" }
            };

            genres = new List<Genre>()
            {
                new Genre() { GenreId = 1, Name = "Genre0" },
                new Genre() { GenreId = 2, Name = "Genre1" },
                new Genre() { GenreId = 3, Name = "Genre2" },
                new Genre() { GenreId = 4, Name = "Genre3" },
                new Genre() { GenreId = 5, Name = "Genre4" },
            };

            bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { BookIndex = 1, AuthorIndex = 1 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 2 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 3 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 4 },
                new BookAuthor() { BookIndex = 2, AuthorIndex = 5 },
                new BookAuthor() { BookIndex = 1, AuthorIndex = 5 },
            };

            bookGenres = new List<BookGenre>()
            {
                new BookGenre() { BookIndex = 1, GenreIndex = 1 },
                new BookGenre() { BookIndex = 1, GenreIndex = 2 },
                new BookGenre() { BookIndex = 2, GenreIndex = 3 },
                new BookGenre() { BookIndex = 2, GenreIndex = 4 },
                new BookGenre() { BookIndex = 2, GenreIndex = 5 },
                new BookGenre() { BookIndex = 1, GenreIndex = 5 }
            };

            foreach (Book item in books)
            {
                item.GenresList = bookGenres;
            }

            foreach (Book item in books)
            {
                item.AuthorsList = bookAuthors;
            }

            foreach (Author item in authors)
            {
                item.Books = bookAuthors;
            }

            foreach (Genre item in genres)
            {
                item.Books = bookGenres;
            }
        }

        /// <summary>
        /// Get book's list
        /// </summary>
        /// <returns>Book's list</returns>
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        /// <summary>
        /// Get author's list
        /// </summary>
        /// <returns>Author's list</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }

        /// <summary>
        /// Get genre's list
        /// </summary>
        /// <returns>List of genres</returns>
        public IEnumerable<Genre> GetGenres()
        {
            return genres;
        }

        /// <summary>
        /// Set list of Book-Genre pairs
        /// </summary>
        /// <returns>List of Book-Genres pairs</returns>
        public IEnumerable<BookGenre> GetBooksGenres()
        {
            return bookGenres;
        }

        /// <summary>
        /// Get list of Book-Genre pairs
        /// </summary>
        /// <returns>List of Book-Author pairs</returns>
        public IEnumerable<BookAuthor> GetBooksAuthors()
        {
            return bookAuthors;
        }
    }
}
