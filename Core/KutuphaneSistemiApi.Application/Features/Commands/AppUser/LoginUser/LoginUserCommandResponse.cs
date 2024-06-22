using KutuphaneSistemiApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse   
    {
        public TokenDTO JWT { get; set; }
        public RefreshTokenDto RefreshToken { get; set; }   
    }   
}
