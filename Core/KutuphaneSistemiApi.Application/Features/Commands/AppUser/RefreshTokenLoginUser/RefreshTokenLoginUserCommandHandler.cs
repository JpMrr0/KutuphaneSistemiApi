using KutuphaneSistemiApi.Application.Abstractions;
using KutuphaneSistemiApi.Application.DTOs;
using KutuphaneSistemiApi.Application.Exceptions;
using KutuphaneSistemiApi.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.RefreshTokenLoginUser
{
    public class RefreshTokenLoginUserCommandHandler : IRequestHandler<RefreshTokenLoginUserCommandRequest, RefreshTokenLoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        public RefreshTokenLoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager,ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<RefreshTokenLoginUserCommandResponse> Handle(RefreshTokenLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(q=>q.RefreshToken == request.RefreshToken);
            if (user != null && user.RefreshTokenExpireDate > DateTime.UtcNow)
            {
                TokenDTO token = _tokenHandler.CreateToken(20);
                RefreshTokenLoginUserCommandResponse response = new() { Token = token };
                return response;
            }
            else if (user == null) throw new RefreshTokenNotFoundError();
            else if (user.RefreshTokenExpireDate < DateTime.UtcNow) throw new RefreshTokenExpiredException();
            else throw new Exception("An unexpected exception occured");
        }
    }
}
