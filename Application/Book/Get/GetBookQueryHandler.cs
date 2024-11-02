using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Get
{
    internal sealed class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto?>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookQueryHandler(IBookRepository bookrepository)
        {
            _bookRepository = bookrepository;
        }
        public async Task<BookDto?> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book is null) return null;
            return new BookDto(book.Id.Value, book.Title, book.Author.FullName, book.PublishedYear, book.Genre);
        }
    }
}
