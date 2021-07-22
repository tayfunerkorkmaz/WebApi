
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult getBook()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            GetBookByIdQuery book = new GetBookByIdQuery(_context);
            book.id = id;
            var result = book.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult createBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context);
                command.newBook = newBook;
                command.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult updateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.id = id;
                command.updatedBook = updatedBook;
                command.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

         [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.id = id;
                command.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

    }
}
