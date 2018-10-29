using Logic.Models;
using System.Collections.Generic;

namespace Logic
{
    public class DataProvider : IDataProvider
    {
        private List<Book> books;

        private List<Author> authors;

        public DataProvider()
        {
            authors = new List<Author>()
            {
                new Author() { Id = 0, Name = "Name0", Surname = "Surname0" },
                new Author() { Id = 1, Name = "Name1", Surname = "Surname1" }
            };

            books = new List<Book>()
            {
                new Book() { Id = 0, Name = "Book0", Author = authors[0] },
                new Book() { Id = 1, Name = "Book1", Author = authors[1] },
                new Book() { Id = 2, Name = "Book2", Author = authors[0] },
                new Book() { Id = 3, Name = "Book3", Author = authors[1] },
            };
        }

        public void SetAuthors(List<Author> authors)
        {
            authors.AddRange(this.authors);
        }

        public void SetBooks(List<Book> books)
        {
            books.AddRange(this.books);
        }
    }
}
