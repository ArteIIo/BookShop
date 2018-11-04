using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Logic
{
    /// <summary>
    /// Realization the author service
    /// </summary>
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// DB context
        /// </summary>
        private LibraryDBContext dBContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorService"/> class.
        /// </summary>
        /// <param name="dBContext">DB context</param>
        public AuthorService(LibraryDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        /// <summary>
        /// Add author to collection
        /// </summary>
        /// <param name="author">New author</param>
        public void AddAuthor(Author author)
        {
            dBContext.Authors.Add(author);
            dBContext.SaveChanges();
        }

        /// <summary>
        /// Get book value by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Book by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public Author GetAuthorById(int id)
        {
            try
            {
                Author author = dBContext.Authors.First(item => item.AuthorId == id);
                return author;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }

        /// <summary>
        /// Return collection of authors
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return dBContext.Authors;
        }

        /// <summary>
        /// Remove author by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        public Author RemoveAuthor(int id)
        {
            try
            {
                Author author = dBContext.Authors.First(item => item.AuthorId == id);
                var pairs = dBContext.BookToAuthor.Where(item => item.AuthorIndex == id);

                dBContext.Authors.Remove(author);
                dBContext.BookToAuthor.RemoveRange(pairs);

                dBContext.SaveChanges();

                return author;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }

        /// <summary>
        /// Set author value by it's id
        /// </summary>
        /// <param name="author">New author</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        public void SetAuthorById(Author author, int id)
        {
            try
            {
                Author currAuthor = dBContext.Authors.First(item => item.AuthorId == id);
                currAuthor.Name = author.Name;
                currAuthor.Surname = author.Surname;
                currAuthor.Books = author.Books;
                dBContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentOutOfRangeException("Id out of range", ex);
            }
        }
    }
}
