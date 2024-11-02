using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Get
{
    public record GetBookQuery(BookId BookId) : IRequest<BookDto>;

}
