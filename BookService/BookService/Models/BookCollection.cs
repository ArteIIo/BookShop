using System.Collections.Generic;

namespace BookService.Models
{
    /// <summary>
    /// Class-realization of the book's collection
    /// </summary>
    public class BookCollection : IBookCollection
    {
        /// <summary>
        /// List with books
        /// </summary>
        private List<Book> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookCollection"/> class.
        /// </summary>
        public BookCollection()
        {
            items = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = "Author0" },
                new Book() { Id = 1, Name = "Book1", Author = "Author1" },
                new Book() { Id = 2, Name = "Book2", Author = "Author2" },
                new Book() { Id = 3, Name = "Book3", Author = "Author3" },
            };
        }

        /// <summary>
        /// Indexer of the book's collection
        /// </summary>
        /// <param name="i">Current index</param>
        /// <returns>Returne value by current index</returns>
        /// <exception cref="System.IndexOutOfRangeException">Throw it if
        /// index out of lenght's range</exception>
        public Book this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }

        /// <summary>
        /// Gets size of the collection
        /// </summary>
        public int Size
        {
            get { return items.Count; }
        }

        /// <summary>
        /// Add book to collection
        /// </summary>
        /// <param name="book">New book</param>
        public void Add(Book book)
        {
            items.Add(book);
        }

        /// <summary>
        /// Return collection of books
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        public IEnumerable<Book> GetBooks()
        {
            return items;
        }

        /// <summary>
        /// Remove book by it's index
        /// </summary>
        /// <param name="id">Index of the selected book</param>
        /// <returns>Deleted book</returns>
        /// <exception cref="System.IndexOutOfRangeException">Throw if index out of range</exception>
        public Book Remove(int id)
        {
            Book deleted = items[id];
            items.RemoveAt(id);

            return deleted;
        }
    }
}
