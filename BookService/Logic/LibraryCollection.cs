using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    /// <summary>
    /// Class-realization of the book's collection
    /// </summary>
    public class LibraryCollection : ILibrary, IBookService, IAuthorService, IGenreService
    {
        /// <summary>
        /// List with books
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// List with authors
        /// </summary>
        private List<Author> authors;

        /// <summary>
        /// List with Genres
        /// </summary>
        private List<Genre> genres;

        /// <summary>
        /// List with Book-Author pairs
        /// </summary>
        private List<BookAuthor> bookAuthors;

        /// <summary>
        /// List with Book-Genre pairs
        /// </summary>
        private List<BookGenre> bookGenres;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryCollection"/> class.
        /// </summary>
        public LibraryCollection(IDataProvider data)
        {
            authors = new List<Author>(data.GetAuthors());
            books = new List<Book>(data.GetBooks());
            genres = new List<Genre>(data.GetGenres());
            bookAuthors = new List<BookAuthor>(data.GetBooksAuthors());
            bookGenres = new List<BookGenre>(data.GetBooksGenres());
        }

        /// <summary>
        /// Get book value by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Book by selected id</returns>
        /// <exception cref="IndexOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public Author GetAuthorById(int id)
        {
            Author author = authors.Find(item => item.AuthorId == id);
            if (author == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return author;
        }

        /// <summary>
        /// Get author value by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>author by selected id</returns>
        /// <exception cref="IndexOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public Book GetBookById(int id)
        {
            Book book = books.Find(item => item.BookId == id);
            if (book == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return book;
        }

        /// <summary>
        /// Set author value by it's id
        /// </summary>
        /// <param name="newAuthor">New author</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="IndexOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public void SetAuthorById(Author author, int id)
        {
            Author currAuthor = authors.Find(item => item.AuthorId == id);
            id = authors.IndexOf(currAuthor);
            authors[id] = author;
        }

        /// <summary>
        /// Set book value by it's id
        /// </summary>
        /// <param name="newBook">New book</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public void SetBookById(Book book, int id)
        {
            Book currBook = books.Find(item => item.BookId == id);
            id = books.IndexOf(currBook);
            books[id] = book;
        }

        /// <summary>
        /// Gets size of the collection
        /// </summary>
        public int BooksCount
        {
            get { return books.Count; }
        }

        /// <summary>
        /// Gets size of the authors's collection
        /// </summary>
        public int AuthorsCount
        {
            get { return authors.Count; }
        }

        /// <summary>
        /// Gets size of the genre's collection
        /// </summary>
        public int GenresCount
        {
            get { return genres.Count; }
        }

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book">New book</param>
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        /// <summary>
        /// Return collection of books
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        /// <summary>
        /// Remove book by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="System.IndexOutOfRangeException">Throw if id out of range</exception>
        public Book RemoveBook(int id)
        {
            Book deleted = books.Find(item => item.BookId == id);
            id = books.IndexOf(deleted);
            books.RemoveAt(id);

            return deleted;
        }

        /// <summary>
        /// Return collection of authors
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }

        /// <summary>
        /// Remove author by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        public Author RemoveAuthor(int id)
        {
            Author author = authors.Find(item => item.AuthorId == id);
            bookAuthors.RemoveAll(items => items.AuthorIndex == author.AuthorId);
            authors.Remove(author);

            return author;
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
            if (bookAuthors.FindAll(item => item.AuthorIndex == authorId
                                             && item.BookIndex == bookId).Count == 0)
            {
                bookAuthors.Add(new BookAuthor()
                {
                    BookIndex = bookId,
                    AuthorIndex = authorId
                });
            }
        }

        /// <summary>
        /// Add author to collection
        /// </summary>
        /// <param name="author">New author</param>
        public void AddAuthor(Author author)
        {
            authors.Add(author);
        }

        /// <summary>
        /// Search books by it's genre
        /// </summary>
        /// <param name="genreIndex">Index of the genre</param>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> SearchByGenre(int genreIndex)
        {
            var gettedBooksGenres = bookGenres.Where(item => item.GenreIndex == genreIndex)
                                              .Select(item => item.BookIndex);

            var gettedBooks = books.Where(item => gettedBooksGenres.Contains(item.BookId));

            return gettedBooks;
        }

        /// <summary>
        /// Search books by it's author
        /// </summary>
        /// <param name="authorIndex">Index of the genre</param>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> SearchByAuthor(int authorIndex)
        {
            var gettedBooksAuthors = bookAuthors.Where(item => item.AuthorIndex == authorIndex)
                                              .Select(item => item.BookIndex);

            var gettedBooks = books.Where(item => gettedBooksAuthors.Contains(item.BookId));

            return gettedBooks;
        }

        /// <summary>
        /// Get genre value by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>genre by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public Genre GetGenreById(int id)
        {
            Genre genre = genres.Find(item => item.GenreId == id);
            if (genre == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return genres.Find(item => item.GenreId == id);
        }

        /// <summary>
        /// Return collection of genres
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Genre> GetGenres()
        {
            return genres;
        }

        /// <summary>
        /// Remove genre by it's id
        /// </summary>
        /// <param name="id">Index of the selected genre</param>
        /// <returns>Deleted Genre</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        public Genre RemoveGenre(int id)
        {
            Genre deletedGenre = null;
            if (bookGenres.FindAll(items => items.GenreIndex == id).Count == 0)
            {
                deletedGenre = genres.Find(item => item.GenreId == id);
                if (deletedGenre == null)
                {
                    throw new ArgumentOutOfRangeException();
                }

                genres.Remove(deletedGenre);
            }

            return deletedGenre;
        }

        /// <summary>
        /// Get List of pairs Book-Author
        /// </summary>
        /// <returns>List of pairs Book-Author</returns>
        public IEnumerable<BookAuthor> GetBookAuthors()
        {
            return bookAuthors;
        }

        /// <summary>
        /// Get List of pairs Book-Genre
        /// </summary>
        /// <returns>List of pairs Book-Genre</returns>
        public IEnumerable<BookGenre> GetBookGenres()
        {
            return bookGenres;
        }

        /// <summary>
        /// Method which update genre reference of the selected book
        /// </summary>
        /// <param name="genreId">Genre's id</param>
        /// <param name="bookId">Book's id</param>
        public void UpdateGenre(int genreId, int bookId)
        {
            if (bookGenres.FindAll(item => item.GenreIndex == genreId
                                             && item.BookIndex == bookId).Count == 0)
            {
                bookGenres.Add(new BookGenre()
                {
                    BookIndex = bookId,
                    GenreIndex = genreId,
                });
            }
        }

        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="newGenre">New genre</param>
        public void AddGenre(Genre newGenre)
        {
            genres.Add(newGenre);
        }
    }
}
