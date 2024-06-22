using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryRequest : IRequest<GetByIdBookQueryResponse>
    {
        public string Id { get; set; }
    }
}
