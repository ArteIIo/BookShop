using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public interface IDataProvider
    {
        void SetBooks(List<Book> books);

        void SetAuthors(List<Author> authors);
    }
}
