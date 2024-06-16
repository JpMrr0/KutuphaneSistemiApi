using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Domain.Entities;
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
        [HttpGet("Create")]
        public async void Create()
        {
            await _bookWriteRepository.AddRangeAsync(new()
            {
                new() {Id=Guid.NewGuid(), Title = "Book1", Author = "Author1", CreatedDate = DateTime.UtcNow, Description = "Desc1", Genre = 0},
                new() {Id=Guid.NewGuid(), Title = "Book2", Author = "Author2", CreatedDate = DateTime.UtcNow, Description = "Desc2", Genre = 0},
                new() {Id=Guid.NewGuid(), Title = "Book3", Author = "Author3", CreatedDate = DateTime.UtcNow, Description = "Desc3", Genre = 0}
            });
            _bookWriteRepository.SaveAsync();
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var a = _bookReadRepository.GetAll();
            return Ok(a.ToArray());
        }
    }
}
