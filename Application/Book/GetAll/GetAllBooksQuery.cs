using Application.Book;
using MediatR;

namespace Application.Authors.GetAll
{
    public record GetAllBooksQuery() : IRequest<IEnumerable<BookDto>>;

}