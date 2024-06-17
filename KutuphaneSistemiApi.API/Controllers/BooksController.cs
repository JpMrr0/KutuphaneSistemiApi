using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Domain.Entities;
using KutuphaneSistemiApi.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneSistemiApi.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IBookWriteRepository _bookWriteRepository;
        public BooksController(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IQueryable<Book> books = _bookReadRepository.GetAll();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Book book = await _bookReadRepository.GetById(id);
            return Ok(book);
        }
        [HttpGet("author/{author}/books")]
        public IActionResult GetByAuthor(string author)
        {
            IQueryable<Book> books = _bookReadRepository.GetWhere(p => p.Author == author);
            return Ok(books);
        }
        [HttpGet("genre/{genre}/books")]
        public IActionResult GetByGenre(string genre)
        {
            IQueryable<Book> books;
            genre = genre.ToLower();
            switch (genre)
            {
                case "fiction":
                    books = _bookReadRepository.GetWhere(p => p.Genre == Domain.Enums.BookGenres.Fiction);
                    break;
                case "nonfiction":
                    books = _bookReadRepository.GetWhere(p => p.Genre == Domain.Enums.BookGenres.Nonfiction);
                    break;
                default:
                    return Ok($"Couldnt get {genre} books");
                    break;
            }
            return Ok(books);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBookAsync([FromBody] Book book)
        {
            var a = await _bookWriteRepository.AddAsync(book);
            await _bookWriteRepository.SaveAsync();
            if (a)
                return Ok("Book added successfully");
            else
                return BadRequest("Couldnt add book");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBookByIdAsync(string id)
        {
            var a = await _bookWriteRepository.DeleteById(id);
            _bookWriteRepository.SaveAsync();
            if (a)
                return Ok("Book removed successfully");
            else
                return BadRequest("Book couldnt removed");
        }
        [HttpDelete]
        public IActionResult RemoveBook([FromBody] Book book)
        {
            var a = _bookWriteRepository.Delete(book);
            _bookWriteRepository.SaveAsync();
            if (a)
                return Ok("Book removed successfully");
            else
                return BadRequest("Couldnt removed book");
        }
        [HttpPatch] 
        public IActionResult UpdateBook([FromBody]Book book)
        {
            var a = _bookWriteRepository.Update(book);
            _bookWriteRepository.SaveAsync();
            if (a) return Ok("Book updated successfully");
            else return BadRequest("Couldnt update book");
        }
    }
}
