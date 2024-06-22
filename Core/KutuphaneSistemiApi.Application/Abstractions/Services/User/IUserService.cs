using KutuphaneSistemiApi.Application.DTOs;
using KutuphaneSistemiApi.Application.Features.Commands.AppUser.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Abstractions.Services.User
{
    public interface IUserService
    {
        Task UpdateRefreshToken(RefreshTokenDto refreshToken, string userId);   
    }
}
