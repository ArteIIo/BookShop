using System.Collections.Generic;

namespace BookService.Models
{
    public class BookCollection : IBookCollection
    {
        List<Book> items;

        public BookCollection()
        {
            items = new List<Book>()
            {
                new Book() {Id = 0, Name = "Book0", Author = "Author0" },
                new Book() {Id = 1, Name = "Book1", Author = "Author1" },
                new Book() {Id = 2, Name = "Book2", Author = "Author2" },
                new Book() {Id = 3, Name = "Book3", Author = "Author3" },
            };
        }

        public Book this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }

        public int Size
        {
            get { return items.Count; }
        }

        public void Add(Book book)
        {
            items.Add(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            return items;
        }

        public Book Remove(int id)
        {
            Book deleted = items[id];
            items.RemoveAt(id);

            return deleted;
        }
    }
}
