using WebApi.DBOperations;
using System;
using System.Linq;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {

        public UpdateBookModel updatedBook { get; set; }
        public int id { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
            {
                throw new InvalidOperationException("Book is not found!");
            }

            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.GenreId = updatedBook.GenreId!= default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount!= default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate!= default ? updatedBook.PublishDate : book.PublishDate;

            _dbContext.SaveChanges();
        }

    }

    public class UpdateBookModel
    {

        public string Title { get; set; }
        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }

    }
}
