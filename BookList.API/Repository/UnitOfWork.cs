using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookList.API.Repository.Repositories;
using BookList.API.Repository.Interfaces;

namespace BookList.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookListEntities _context;

        public UnitOfWork(BookListEntities context)
        {
            _context = context;
            Books = new BookRepository(_context);
        }
        public IBookRepository Books { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}