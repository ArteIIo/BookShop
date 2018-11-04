using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Models;

namespace Logic
{
    public class LibraryService : ILibrary
    {
        /// <summary>
        /// DB context
        /// </summary>
        private LibraryDBContext dBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class.
        /// </summary>
        /// <param name="dBContext">DB context</param>
        public LibraryService(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        /// <summary>
        /// Get List of pairs Book-Author
        /// </summary>
        /// <returns>List of pairs Book-Author</returns>
        public IEnumerable<BookAuthor> GetBookAuthors()
        {
            return dBContext.BookToAuthor;
        }

        /// <summary>
        /// Get List of pairs Book-Genre
        /// </summary>
        /// <returns>List of pairs Book-Genre</returns>
        public IEnumerable<BookGenre> GetBookGenres()
        {
            return dBContext.BookToGenre;
        }

        /// <summary>
        /// Search books by it's author
        /// </summary>
        /// <param name="authorIndex">Index of the genre</param>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> SearchByAuthor(int authorIndex)
        {
            var gettedBooksAuthors = dBContext.BookToAuthor.Where(item => item.AuthorIndex == authorIndex)
                                              .Select(item => item.BookIndex);

            var gettedBooks = dBContext.Books.Where(item => gettedBooksAuthors.Contains(item.BookId));

            return gettedBooks;
        }

        /// <summary>
        /// Search books by it's genre
        /// </summary>
        /// <param name="genreIndex">Index of the genre</param>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> SearchByGenre(int genreIndex)
        {
            var gettedBooksGenres = dBContext.BookToGenre.Where(item => item.GenreIndex == genreIndex)
                                              .Select(item => item.BookIndex);

            var gettedBooks = dBContext.Books.Where(item => gettedBooksGenres.Contains(item.BookId));

            return gettedBooks;
        }

        /// <summary>
        /// Method which update author reference of the selected book
        /// </summary>
        /// <param name="authorId">Author's id</param>
        /// <param name="bookId">Book's id</param>
        /// <exception cref="IndexOutOfRangeException">Throw when ether author's id
        /// or book's id out of range of their collection's count</exception>
        public void UpdateAuthor(int authorId, int bookId)
        {
            var isContains = dBContext.BookToAuthor.Any(item => item.AuthorIndex == authorId
                                         && item.BookIndex == bookId);
            if (!isContains)
            {
                dBContext.BookToAuthor.Add(new BookAuthor()
                {
                    BookIndex = bookId,
                    AuthorIndex = authorId
                });
                dBContext.SaveChanges();
            }
        }

        /// <summary>
        /// Method which update genre reference of the selected book
        /// </summary>
        /// <param name="genreId">Genre's id</param>
        /// <param name="bookId">Book's id</param>
        public void UpdateGenre(int genreId, int bookId)
        {
            var items = dBContext.BookToGenre.Any(item => item.GenreIndex == genreId
                                         && item.BookIndex == bookId);
            if (items == null)
            {
                dBContext.BookToGenre.Add(new BookGenre()
                {
                    BookIndex = bookId,
                    GenreIndex = genreId
                });
                dBContext.SaveChanges();
            }
        }
    }
}
