using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.Book.DeleteBook
{
    public class DeleteBookCommandRequest : IRequest<DeleteBookCommandResponse>
    {
        public string Id { get; set; }
    }
}
