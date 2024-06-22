using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("User couldnt created")
        {
        }
        public UserCreateFailedException(string? message) : base(message)
        {  
        }
        public UserCreateFailedException(string? message, Exception? exception) :base(message, exception)
        {
        }
    }
}
