using KutuphaneSistemiApi.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQueryRequest, GetAllBooksQueryResponse>
    {
        private readonly IBookReadRepository _bookReadRepository;
        public GetAllBooksQueryHandler(IBookReadRepository bookReadRepository) 
        {
            _bookReadRepository = bookReadRepository;
        }
        public async Task<GetAllBooksQueryResponse> Handle(GetAllBooksQueryRequest request, CancellationToken cancellationToken)
        {
            int total = _bookReadRepository.GetAll().Count();
            var books = _bookReadRepository.GetAll();
            var response = new GetAllBooksQueryResponse()
            {
                Total = total,
                Books = books
            };
            return response;
        }
    }
}
