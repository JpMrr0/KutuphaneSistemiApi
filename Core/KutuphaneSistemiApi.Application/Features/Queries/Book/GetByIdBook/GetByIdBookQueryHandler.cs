using KutuphaneSistemiApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQueryRequest, GetByIdBookQueryResponse>
    {
        private readonly IBookReadRepository _bookReadRepository;
        public GetByIdBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        public async Task<GetByIdBookQueryResponse> Handle(GetByIdBookQueryRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookReadRepository.GetById(request.Id);
            GetByIdBookQueryResponse response = new GetByIdBookQueryResponse();
            response.Book = book;
            return response;
        }
    }
}
