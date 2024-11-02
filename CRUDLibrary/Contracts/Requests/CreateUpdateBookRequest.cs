using Domain.Author;

namespace CRUDLibrary.Contracts.Requests
{
    public record CreateUpdateBookRequest(
    string Title,
    Guid AuthorId,
    DateTime PublishedYear,
    string Genre);
}
