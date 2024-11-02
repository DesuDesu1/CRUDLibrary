using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Book
{
    public interface IBookRepository
    {
        void Add(Book book);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(BookId id);
        void Remove(Book book);
        void Update(Book book);
    }
}
