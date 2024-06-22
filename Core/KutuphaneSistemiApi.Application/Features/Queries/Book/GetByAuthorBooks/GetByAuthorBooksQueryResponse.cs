using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByAuthorBook
{
    public class GetByAuthorBooksQueryResponse
    {
        public int Total { get; set; }
        public object Books { get; set; }
    }
}
