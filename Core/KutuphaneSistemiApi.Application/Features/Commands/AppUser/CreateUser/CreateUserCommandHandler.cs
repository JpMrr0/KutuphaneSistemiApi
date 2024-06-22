using KutuphaneSistemiApi.Application.Exceptions;
using KutuphaneSistemiApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var ifUserExists = await _userManager.FindByNameAsync(request.Username);
            if (ifUserExists != null) { throw new UsernameAlreadyExistsException(); }
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id=Guid.NewGuid().ToString(),
                Email = request.Email,
                UserName=request.Username,
                FullName = request.Fullname,
            },request.Password);
            CreateUserCommandResponse response = new() {Success = result.Succeeded };
            if (result.Succeeded)
                response.Message = "User created successfully";
            else { 
                foreach(var error in result.Errors)
                {
                    response.Message += $"{error.Description} ";
                }
            }
            return response;
        }
    }
}
