using KutuphaneSistemiApi.Application.ViewModels.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandRequest : User_Update_VM ,IRequest<UpdateUserCommandResponse>
    {
    }
}
