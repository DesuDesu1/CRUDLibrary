using Application.Data;
using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Update
{
    internal sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitofWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitofWork;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            BookId bookId = new BookId(request.BookId);
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }
                book.Update(
                request.Title,
                new Domain.Author.AuthorId(request.AuthorId),
                request.PublishedYear,
                request.Genre);

            _bookRepository.Update(book);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
