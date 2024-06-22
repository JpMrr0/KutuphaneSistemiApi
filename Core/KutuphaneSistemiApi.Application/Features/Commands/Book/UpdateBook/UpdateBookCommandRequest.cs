using KutuphaneSistemiApi.Application.ViewModels.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.Book.UpdateBook
{
    public class UpdateBookCommandRequest : Update_Book_VM , IRequest<UpdateBookCommandResponse>
    {
    }
}
