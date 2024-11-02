using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Delete
{
    public record DeleteBookCommand(Guid BookId) : IRequest;

}
