using KutuphaneSistemiApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<KutuphaneSistemiApi.Domain.Entities.Identity.AppUser> _userManager;
        public UpdateUserCommandHandler(UserManager<KutuphaneSistemiApi.Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult updateResult = await _userManager.UpdateAsync(request);
            if (updateResult.Succeeded)
            {
                return new() { ResponseMessage = "User updated successfully." };
            }
            throw new Exception("An error occured while updating user.");
        }
    }
}
