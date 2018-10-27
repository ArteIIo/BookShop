using System.Collections.Generic;

namespace BookService.Models
{
    public interface IBookCollection
    {
        int Size { get; }

        Book this[int i]{ get; set; }

        IEnumerable<Book> GetBooks();

        void Add(Book book);

        Book Remove(int id);
    }
}
