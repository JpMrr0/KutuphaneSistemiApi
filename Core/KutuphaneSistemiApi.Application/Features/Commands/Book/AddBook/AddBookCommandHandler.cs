using KutuphaneSistemiApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.Book.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, AddBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        public AddBookCommandHandler(IBookWriteRepository bookWriteRepository)
        {
            _bookWriteRepository = bookWriteRepository;
        }
        public async Task<AddBookCommandResponse> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            var added = await _bookWriteRepository.AddAsync(new()
            {
                Title = request.Title,
                Author = request.Author,
                Description = request.Description,
                Genre = request.Genre,
            });
            await _bookWriteRepository.SaveAsync();
            if (added)
            {
                return new() { IsAdded = true };
            }
            else
                return new() { IsAdded = false };
        }
    }
}
