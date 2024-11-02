using Domain.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Create
{
    public record CreateBookCommand(
        Guid Id,
        string Title,
        Guid AuthorId,
        DateTime PublishedYear,
        string Genre) : IRequest;
}
