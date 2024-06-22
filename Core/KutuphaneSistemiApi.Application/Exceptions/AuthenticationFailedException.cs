using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Exceptions
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException() : base("Login failed")
        {
        }

        public AuthenticationFailedException(string? message) : base(message)
        {
        }

        public AuthenticationFailedException(string? message, Exception? exception) : base(message, exception)
        {
        }
    }
}
