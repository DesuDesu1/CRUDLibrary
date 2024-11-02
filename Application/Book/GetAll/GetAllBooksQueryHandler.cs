using Application.Book;
using Domain.Author;
using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAll
{
    internal sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IAuthorRepository arepository, IBookRepository brepository)
        {
            _authorRepository = arepository;
            _bookRepository = brepository;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();
            var bookDtos = books.Select(book => new BookDto(
            book.Id.Value,
            book.Title,
            book.Author.FullName,
            book.PublishedYear,
            book.Genre
            ));

            return bookDtos;
        }
    }
}
