using FluentValidation;
using System;

namespace WebApi.BookOperations.UpdateBook
{


    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {

        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.updatedBook.GenreId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(command => command.updatedBook.Title).NotNull().NotEmpty().MinimumLength(4);
            RuleFor(command => command.updatedBook.PageCount).NotNull().NotEmpty().GreaterThan(2);
            RuleFor(command => command.updatedBook.PublishDate.Date).NotEmpty().NotNull().LessThan(DateTime.Now.Date);
        }
    }
}