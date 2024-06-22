using KutuphaneSistemiApi.Application.Abstractions;
using KutuphaneSistemiApi.Application.Abstractions.Services.User;
using KutuphaneSistemiApi.Application.DTOs;
using KutuphaneSistemiApi.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _loginManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> loginManager, ITokenHandler tokenHandler,IUserService userService)
        {
            _userManager = userManager;
            _loginManager = loginManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            LoginUserCommandResponse response = new();
            var user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if(user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            }
            if (user == null)
                throw new UserNotFoundException();
            SignInResult result = await _loginManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                response.JWT = _tokenHandler.CreateToken(20);
                RefreshTokenDto refreshToken = _tokenHandler.CreateRefreshToken(response.JWT.ExpireDate, response.JWT.ExpireDate.Second+ response.JWT.ExpireDate.Second/2);
                response.RefreshToken = refreshToken;
                await _userService.UpdateRefreshToken(refreshToken,user.Id);
                return response;
            }
            throw new UserNotFoundException();
        }
    }
}
