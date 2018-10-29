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
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 1, Name = "Name1", Surname = "Surname1" },
                new Author() { Id = 2, Name = "Name2", Surname = "Surname2" },
                new Author() { Id = 3, Name = "Name3", Surname = "Surname3" },
                new Author() { Id = 4, Name = "Name4", Surname = "Surname4" },
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
                new Genre() { Id = 4, Name = "Genre4" },
            };

            bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor() { Book = books[0], Author = authors[0] },
                new BookAuthor() { Book = books[0], Author = authors[1] },
                new BookAuthor() { Book = books[1], Author = authors[2] },
                new BookAuthor() { Book = books[1], Author = authors[3] },
                new BookAuthor() { Book = books[1], Author = authors[4] },
                new BookAuthor() { Book = books[0], Author = authors[4] },
            };

            bookGenres = new List<BookGenre>()
            {
                new BookGenre() { Book = books[0], Genre = genres[0] },
                new BookGenre() { Book = books[0], Genre = genres[1] },
                new BookGenre() { Book = books[1], Genre = genres[2] },
                new BookGenre() { Book = books[1], Genre = genres[3] },
                new BookGenre() { Book = books[1], Genre = genres[4] },
                new BookGenre() { Book = books[0], Genre = genres[4] }
            };

            foreach(Book item in books)
            {
                item.Genres = bookGenres;
            }

            foreach (Book item in books)
            {
                item.Authors = bookAuthors;
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
        /// Set book's authors
        /// </summary>
        /// <param name="authors">List of authors</param>
        public void SetAuthors(List<Author> authors)
        {
            authors.AddRange(this.authors);
        }

        /// <summary>
        /// Set book's list
        /// </summary>
        /// <param name="books">List of books</param>
        public void SetBooks(List<Book> books)
        {
            books.AddRange(this.books);
        }

        /// <summary>
        /// Set genre's list
        /// </summary>
        /// <param name="genres">List of genres</param>
        public void SetGenres(List<Genre> genres)
        {
            genres.AddRange(this.genres);
        }

        /// <summary>
        /// Set list of Book-Genre pairs
        /// </summary>
        /// <param name="bookGenres">List of Book-Genre pairs</param>
        public void SetBooksGenres(List<BookGenre> bookGenres)
        {
            bookGenres.AddRange(this.bookGenres);
        }

        /// <summary>
        /// Set list of Book-Author pairs
        /// </summary>
        /// <param name="bookAuthors">List of Book-Author pairs</param>
        public void SetBooksAuthors(List<BookAuthor> bookAuthors)
        {
            bookAuthors.AddRange(this.bookAuthors);
        }
    }
}
