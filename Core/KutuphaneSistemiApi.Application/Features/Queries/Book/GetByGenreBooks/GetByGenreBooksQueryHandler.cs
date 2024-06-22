using KutuphaneSistemiApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByGenreBooks
{
    public class GetByGenreBooksQueryHandler : IRequestHandler<GetByGenreBooksQueryRequest, GetByGenreBooksQueryResponse>
    {
        private readonly IBookReadRepository _bookReadRepository;
        public GetByGenreBooksQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        public async Task<GetByGenreBooksQueryResponse> Handle(GetByGenreBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var count = _bookReadRepository.GetWhere(
                q => q.Genre == request.Genre).Count();
            var books = _bookReadRepository.GetWhere(
                q=>q.Genre == request.Genre);
            return new()
            {
                Total= count,
                Books = books
            };
        }
    }
}
