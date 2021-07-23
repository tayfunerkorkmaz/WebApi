
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using System;
using AutoMapper;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {       
            _mapper = mapper;
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
            GetBookByIdQuery book = new GetBookByIdQuery(_context, _mapper);
            book.id = id;
            var result = book.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult createBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context, _mapper);
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
