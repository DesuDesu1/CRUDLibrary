using Domain.Author;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Book.Create
{
    public sealed class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator(IAuthorRepository authorRepository) 
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Cannot be empty or null.");

            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Название не может быть пустым.")
                .MaximumLength(255).WithMessage("Превышен лимит на максимальную длительность названия.");

            RuleFor(c => c.Genre)
                .NotEmpty().WithMessage("Жанр не может быть пустым.")
                .MaximumLength(100).WithMessage("Превышен лимит на максимальную длительность жанра.");

            RuleFor(c => c.AuthorId)
            .NotEmpty().WithMessage("Необходимо указать автора.")
            .MustAsync(async (authorId, cancellation) =>
            {
                var author = await authorRepository.GetByIdAsync(new AuthorId(authorId));
                return author != null;
            })
            .WithMessage("Указанный автор не существует.");

        }
    }
}
