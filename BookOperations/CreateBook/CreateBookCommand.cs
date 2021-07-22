using WebApi.DBOperations;
using System;
using System.Linq;
using WebApi.Entities;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {

        public CreateBookModel newBook { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == newBook.Title);

            if (book is not null)
            {
                throw new InvalidOperationException("Book is already exist!");
            }
            book = new Book();
            book.Title = newBook.Title;
            book.GenreId = newBook.GenreId;
            book.PageCount = newBook.PageCount;
            book.PublishDate = newBook.PublishDate;

            _dbContext.Add(book);
            _dbContext.SaveChanges();
        }

    }

    public class CreateBookModel
    {

        public string Title { get; set; }
        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }

    }
}
