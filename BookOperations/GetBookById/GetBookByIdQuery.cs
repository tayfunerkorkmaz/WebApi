using WebApi.DBOperations;
using System.Linq;
using WebApi.Common;
using AutoMapper;

namespace WebApi.BookOperations.GetBookById
{
    public class GetBookByIdQuery
    {

        public int id { get; set; }
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;
        public GetBookByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {      
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public BookByIdViewModel Handle()
        {
            //var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            var book = _dbContext.Books.Where(x => x.Id == id).SingleOrDefault();
            if (book is null)
            {
                return null;
            }

            var _book = _mapper.Map<BookByIdViewModel>(book);

            // _book.Title = book.Title;
            // _book.Genre = ((GenreEnum)book.GenreId).ToString();
            // _book.PageCount = book.PageCount;
            // _book.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");

            return _book;
        }
    }
    public class BookByIdViewModel
    {

        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }


    }
}