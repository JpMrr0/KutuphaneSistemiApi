using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByAuthorBook
{
    public class GetByAuthorBooksQueryRequest : IRequest<GetByAuthorBooksQueryResponse>
    {
        public string Author { get; set; }
    }
}
