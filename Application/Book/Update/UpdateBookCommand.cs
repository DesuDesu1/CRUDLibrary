using Domain.Author;
using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Update
{
    public record UpdateBookCommand(
        Guid BookId,
        string Title,
        Guid AuthorId,
        DateTime PublishedYear,
        string Genre) : IRequest;


}
