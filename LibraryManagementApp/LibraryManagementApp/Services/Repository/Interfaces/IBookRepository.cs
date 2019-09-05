using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizerTest.Data.Entities;

namespace WizerTest.Services.Repository.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        Book CreateBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(Book book);
    }
}
