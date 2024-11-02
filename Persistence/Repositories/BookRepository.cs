using Domain.Author;
using Domain.Book;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public Task<Book?> GetByIdAsync(BookId id)
        {
            return _context.Books.Include(b => b.Author).SingleOrDefaultAsync(b => b.Id == id);
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

    }
}
