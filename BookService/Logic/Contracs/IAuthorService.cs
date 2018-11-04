using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Interface of the author's service
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Get author value by it's id
        /// </summary>
        /// <param name="id">Index of the selected author</param>
        /// <returns>author by selected id</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        Author GetAuthorById(int id);

        /// <summary>
        /// Return collection of authors
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Set author value by it's id
        /// </summary>
        /// <param name="author">New author</param>
        /// <param name="id">Index of the new book</param>
        /// /// <exception cref="IndexOutOfRangeException">Throw when id out of
        /// list's count range</exception>
        void SetAuthorById(Author author, int id);

        /// <summary>
        /// Remove author by it's id
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw if id out of range</exception>
        Author RemoveAuthor(int id);

        /// <summary>
        /// Add author to collection
        /// </summary>
        /// <param name="author">New author</param>
        void AddAuthor(Author author);
    }
}
