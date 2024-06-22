using KutuphaneSistemiApi.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandRequest : User_Registiration_VM, IRequest<CreateUserCommandResponse>
    {
    }
}
