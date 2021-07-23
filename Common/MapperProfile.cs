using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookById;
using WebApi.Entities;


namespace WebApi.Common{

    public class MapperProfile: Profile{

        public MapperProfile(){
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book, BookByIdViewModel>().ForMember(dest=> dest.Genre, memberOptions=>memberOptions.MapFrom(sourceMember=> ((GenreEnum)sourceMember.GenreId).ToString()))
            .ForMember(dest=> dest.PublishDate, memberOptions=>memberOptions.MapFrom(sourceMember=> (sourceMember.PublishDate.Date).ToString("dd/MM/yyyy")));
        }

    }
}