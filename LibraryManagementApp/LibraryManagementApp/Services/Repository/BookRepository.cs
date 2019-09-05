using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizerTest.Data;
using WizerTest.Data.Entities;
using WizerTest.Services.Repository.Interfaces;

namespace WizerTest.Services.Repository
{
    public class BookRepository : IBookRepository
    {
        private LibraryDbContext _bookContext;

        public BookRepository(LibraryDbContext bookContext)
        {
            _bookContext = bookContext;
        }
        public Book CreateBook(Book book)
        {
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
            return book;
        }

        public Book DeleteBook(Book book)
        {
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
            return book;
        }

        public ICollection<Book> GetBooks()
        {
            return _bookContext.Books.OrderBy(b => b.Id).ToList();
        }

        public Book GetBook(int bookId)
        {
            return _bookContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }


        public Book UpdateBook(Book book)
        {
            _bookContext.Books.Update(book);
            _bookContext.SaveChanges();
            return book;
        }
    }
}
