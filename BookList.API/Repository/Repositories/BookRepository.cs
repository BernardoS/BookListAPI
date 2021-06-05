using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookList.API.Repository.Interfaces;

namespace BookList.API.Repository.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookListEntities context) : base(context)
        {
        }
        public IEnumerable<Book> GetTopExpensiveBook(int count)
        {
            return BookListContext.Book.OrderByDescending(b => b.Preco).Take(count).ToList();
        }


        public IEnumerable<Book> GetTopInexpensiveBook(int count)
        {
            return BookListContext.Book.OrderBy(b => b.Preco).Take(count).ToList();
        }

        public BookListEntities BookListContext
        {
            get { return Context as BookListEntities; }
        }
    }
}