using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Exceptions
{
    public class UserNotDeletedException : Exception
    {
        public UserNotDeletedException() : base("User can not deleted.")
        {
        }

        public UserNotDeletedException(string? message) : base(message)
        {
        }

        public UserNotDeletedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
