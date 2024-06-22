using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public const string Admin = "admin";
        public const string User = "user";
        public const string Premium = "premium";
    }
}
