using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByGenreBooks
{
    public class GetByGenreBooksQueryResponse
    {
        public int Total { get; set; }
        public object Books { get; set; }
    }
}
