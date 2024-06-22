using KutuphaneSistemiApi.Application.ViewModels.Books;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.Book.AddBook
{
    public class AddBookCommandRequest : Create_Book_VM,IRequest<AddBookCommandResponse>
    {
    }
}
