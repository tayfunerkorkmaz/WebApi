using WebApi.DBOperations;
using System;
using System.Linq;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {

        public int id { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public DeleteBookCommand(BookStoreDbContext dbContext)
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

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

    }

}
