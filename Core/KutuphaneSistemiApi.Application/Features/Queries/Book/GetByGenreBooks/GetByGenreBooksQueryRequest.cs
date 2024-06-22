using KutuphaneSistemiApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Queries.Book.GetByGenreBooks
{
    public class GetByGenreBooksQueryRequest : IRequest<GetByGenreBooksQueryResponse>
    {
        public BookGenres Genre { get; set; }
    }
}
