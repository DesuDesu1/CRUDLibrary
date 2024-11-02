using Application.Data;
using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Delete
{
    internal sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            BookId bookId = new BookId(request.BookId);
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }
            _bookRepository.Remove(book);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
