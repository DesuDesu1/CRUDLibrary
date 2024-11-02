using Application.Data;
using Domain.Author;
using Domain.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Create
{
    internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookCommandHandler(
            IBookRepository productRepository,
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork)
        {
            _bookRepository = productRepository;
            _unitOfWork = unitOfWork;
            _authorRepository = authorRepository;
        }
        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(new AuthorId(request.AuthorId));
            var book = new Domain.Book.Book(
                new BookId(request.Id),
                request.Title,
                author.Id,
                author,
                request.PublishedYear,
                request.Genre);

            _bookRepository.Add(book);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
