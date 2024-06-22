using KutuphaneSistemiApi.Application.Features.Commands.Book.AddBook;
using KutuphaneSistemiApi.Application.Features.Commands.Book.DeleteBook;
using KutuphaneSistemiApi.Application.Features.Commands.Book.UpdateBook;
using KutuphaneSistemiApi.Application.Features.Queries.Book.GetAllBooks;
using KutuphaneSistemiApi.Application.Features.Queries.Book.GetByAuthorBook;
using KutuphaneSistemiApi.Application.Features.Queries.Book.GetByGenreBooks;
using KutuphaneSistemiApi.Application.Features.Queries.Book.GetByIdBook;
using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Application.ViewModels.Books;
using KutuphaneSistemiApi.Domain.Entities;
using KutuphaneSistemiApi.Domain.Enums;
using KutuphaneSistemiApi.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KutuphaneSistemiApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BooksController : ControllerBase
    {
        readonly private IMediator _mediator;
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IBookWriteRepository _bookWriteRepository;
        public BooksController(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository,IMediator mediator)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllBooksQueryRequest getAllBooksQueryRequest = new();
            GetAllBooksQueryResponse getAllBooksQueryResponse = await _mediator.Send(getAllBooksQueryRequest);
            return Ok(getAllBooksQueryResponse);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetByIdBookQueryRequest getByIdBookQueryRequest)
        {
            if (!Guid.TryParse(getByIdBookQueryRequest.Id, out Guid result))
            {
                return BadRequest("Invalid id");
            }
            GetByIdBookQueryResponse getByIdBookQueryResponse = await _mediator.Send(getByIdBookQueryRequest);
            return Ok(getByIdBookQueryResponse);
        }
        [HttpGet("author/{Author}/books")]
        public async Task<IActionResult> GetByAuthor([FromRoute]GetByAuthorBooksQueryRequest getByAuthorBooksQueryRequest)
        {
            GetByAuthorBooksQueryResponse getByAuthorBooksQueryResponse = await _mediator.Send(getByAuthorBooksQueryRequest);
            return Ok(getByAuthorBooksQueryResponse);
        }
        [HttpGet("genre/{Genre}/books")]
        public async Task<IActionResult> GetByGenre(string Genre)
        {
            IQueryable<Book> books;
            Genre = Genre.ToLower();
            BookGenres genre;
            switch (Genre)
            {
                case "fiction":
                    genre = (BookGenres)0;
                    break;
                case "nonfiction":
                    genre = (BookGenres)1;
                    break;
                default:
                    return Ok($"{Genre} genre doesn't exist");
            }
            GetByGenreBooksQueryRequest getByGenreBooksQueryRequest = new() { Genre = genre};
            GetByGenreBooksQueryResponse getByGenreBooksQueryResponse = await _mediator.Send(getByGenreBooksQueryRequest);
            return Ok(getByGenreBooksQueryResponse);
        }
        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] AddBookCommandRequest addBookCommandRequest)
        {
            AddBookCommandResponse addBookCommandResponse = await _mediator.Send(addBookCommandRequest);
            if (addBookCommandResponse.IsAdded) return StatusCode((int)HttpStatusCode.Created);
            else return StatusCode((int)HttpStatusCode.BadRequest);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBook([FromBody] DeleteBookCommandRequest deleteBookCommandRequest)
        {
            DeleteBookCommandResponse deleteBookCommandResponse = await _mediator.Send(deleteBookCommandRequest);
            if (deleteBookCommandResponse.IsDeleted)
            {
                return StatusCode((int)(HttpStatusCode.OK));
            }
            else return StatusCode((int)HttpStatusCode.BadRequest);
        }
        [HttpPut] 
        public async Task<IActionResult> UpdateBook([FromBody]UpdateBookCommandRequest updateBookCommandRequest)
        {
            UpdateBookCommandResponse updateBookCommandResponse = await _mediator.Send(updateBookCommandRequest);
            if(updateBookCommandResponse.IsUpdated) return StatusCode((int)(HttpStatusCode.OK));
            else return StatusCode((int)HttpStatusCode.BadRequest);
        }
    }
}
