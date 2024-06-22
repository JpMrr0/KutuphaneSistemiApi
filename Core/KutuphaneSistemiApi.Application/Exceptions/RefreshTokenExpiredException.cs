using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Exceptions
{
    public class RefreshTokenExpiredException : Exception
    {
        public RefreshTokenExpiredException() : base("Refresh token is expired")
        {
        }

        public RefreshTokenExpiredException(string? message) : base(message)
        {
        }

        public RefreshTokenExpiredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
