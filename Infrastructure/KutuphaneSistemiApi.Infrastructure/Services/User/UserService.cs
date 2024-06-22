using KutuphaneSistemiApi.Application.Abstractions.Services.User;
using KutuphaneSistemiApi.Application.DTOs;
using KutuphaneSistemiApi.Application.Exceptions;
using KutuphaneSistemiApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task UpdateRefreshToken(RefreshTokenDto refreshToken, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user is not null)
            {
                user.RefreshToken = refreshToken.RefreshToken;
                user.RefreshTokenExpireDate = refreshToken.RefreshTokenExpireDate;
                await _userManager.UpdateAsync(user);
            }
            else { 
            throw new UserNotFoundException("User not found while generating refresh token.");
            }
        }
    }
}
