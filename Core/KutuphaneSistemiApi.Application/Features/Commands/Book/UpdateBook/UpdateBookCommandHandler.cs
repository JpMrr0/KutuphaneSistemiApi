using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Application.ViewModels.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookReadRepository _bookReadRepository;
        public UpdateBookCommandHandler(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;   

        }
        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookReadRepository.GetById(request.Id);
            var book2 = new Domain.Entities.Book()
            {
                Author = request.Author,
                Id = Guid.Parse(request.Id),
                CreatedDate = book.CreatedDate,
                Description = request.Description,
                Genre = request.Genre,
                Title = request.Title,
            };
            var isUpdated = _bookWriteRepository.Update(book2);
            await _bookWriteRepository.SaveAsync();
            return new() { IsUpdated = isUpdated };
        }
    }
}
