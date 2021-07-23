using FluentValidation;
using System;

namespace WebApi.BookOperations.CreateBook{


    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>{

        public CreateBookCommandValidator(){
            RuleFor(command => command.newBook.GenreId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(command => command.newBook.Title).NotNull().NotEmpty().MinimumLength(4);
            RuleFor(command => command.newBook.PageCount).NotNull().NotEmpty().GreaterThan(2);
            RuleFor(command => command.newBook.PublishDate.Date).NotEmpty().NotNull().LessThan(DateTime.Now.Date);;


        }
    }
}