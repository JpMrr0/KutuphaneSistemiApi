using KutuphaneSistemiApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Features.Commands.AppUser.RefreshTokenLoginUser
{
    public class RefreshTokenLoginUserCommandResponse
    {
        public TokenDTO Token { get; set; }
    }
}
