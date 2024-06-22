using KutuphaneSistemiApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        public DeleteBookCommandHandler(IBookWriteRepository bookWriteRepository)
        {
            _bookWriteRepository = bookWriteRepository;
        }
        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await _bookWriteRepository.DeleteById(request.Id);
            await _bookWriteRepository.SaveAsync();
            return new() { IsDeleted = isDeleted };
        }
    }
}
