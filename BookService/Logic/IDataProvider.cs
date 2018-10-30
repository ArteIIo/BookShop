using Logic.Models;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Interface of the dataprovider abstruction
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Get book's list
        /// </summary>
        /// <returns>Book's list</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Get author's list
        /// </summary>
        /// <returns>Author's list</returns>
        IEnumerable<Author> GetAuthors();
    }
}
