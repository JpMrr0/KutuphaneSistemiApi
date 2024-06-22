using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Exceptions
{
    public class RefreshTokenNotFoundError : Exception
    {
        public RefreshTokenNotFoundError() : base("Refresh token not found")
        {
        }

        public RefreshTokenNotFoundError(string? message) : base(message)
        {
        }

        public RefreshTokenNotFoundError(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
