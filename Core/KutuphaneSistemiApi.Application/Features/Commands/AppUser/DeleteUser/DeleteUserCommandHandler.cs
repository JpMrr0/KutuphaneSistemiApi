using KutuphaneSistemiApi.Application.Exceptions;
using KutuphaneSistemiApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly UserManager<KutuphaneSistemiApi.Domain.Entities.Identity.AppUser> _userManager;
        public DeleteUserCommandHandler(UserManager<KutuphaneSistemiApi.Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if(user == null) 
            {
                throw new UserNotFoundException();
            }
            IdentityResult deleteIdentityResult = await _userManager.DeleteAsync(user);
            if(deleteIdentityResult.Succeeded)
            {
                return new() { ResponseMessage="User deleted successfully."};
            }
            else
                throw new UserNotDeletedException();
        }   
    }
}
