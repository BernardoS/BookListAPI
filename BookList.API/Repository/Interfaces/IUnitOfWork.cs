using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookList.API.Repository.Interfaces;

namespace BookList.API.Repository
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }

        int Complete();
    }
}