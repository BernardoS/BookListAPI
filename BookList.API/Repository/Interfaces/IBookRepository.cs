using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.API.Repository.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        IEnumerable<Book> GetTopExpensiveBook(int count);
        IEnumerable<Book> GetTopInexpensiveBook(int count);
    }
}
