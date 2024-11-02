using MediatR;

namespace Application.Authors.GetAll
{
    public record GetAllAuthorsQuery() : IRequest<IEnumerable<AuthorDto>>;

}