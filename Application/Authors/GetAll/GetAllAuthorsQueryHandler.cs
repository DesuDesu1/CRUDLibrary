using Application.Data;
using Domain.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.GetAll
{
    internal sealed class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDto>>
    {
        private readonly IAuthorRepository _repository;

        public GetAllAuthorsQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();
            var test =  authors.Select(a => new AuthorDto(
                a.Id.Value,
                a.FullName,
                a.Birthday
            ));
            return test;
        }
    }
}
