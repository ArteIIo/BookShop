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
        /// Set list of books
        /// </summary>
        /// <param name="books">List to fill</param>
        void SetBooks(List<Book> books);

        /// <summary>
        /// Set list of authors
        /// </summary>
        /// <param name="authors">List to fill</param>
        void SetAuthors(List<Author> authors);
    }
}
