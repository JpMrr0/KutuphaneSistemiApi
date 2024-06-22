using KutuphaneSistemiApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Abstractions
{
    public interface ITokenHandler
    {
        TokenDTO CreateToken(int seconds);
        RefreshTokenDto CreateRefreshToken(DateTime JwtExpireDate, int addSeconds);
    }
}
