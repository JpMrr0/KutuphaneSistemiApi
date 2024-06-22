using KutuphaneSistemiApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByAuthorBook
{
    public class GetByAuthorBooksQueryHandler : IRequestHandler<GetByAuthorBooksQueryRequest, GetByAuthorBooksQueryResponse>
    {
        private readonly IBookReadRepository _bookReadRepository;
        public GetByAuthorBooksQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        public async Task<GetByAuthorBooksQueryResponse> Handle(GetByAuthorBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var count = _bookReadRepository.GetWhere(q => q.Author == request.Author).Count();
            var books = _bookReadRepository.GetWhere(q=>q.Author == request.Author);
            return new()
            {
                Total = count,
                Books = books,
            };
        }
    }
}
