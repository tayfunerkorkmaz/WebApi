using FluentValidation;

namespace WebApi.BookOperations.GetBookById{


    public class GetBookByIdCommandValidator: AbstractValidator<GetBookByIdQuery>{

        public GetBookByIdCommandValidator(){
            RuleFor(query => query.id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}