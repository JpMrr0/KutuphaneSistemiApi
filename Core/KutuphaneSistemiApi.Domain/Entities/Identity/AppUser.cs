using KutuphaneSistemiApi.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public MembershipTypes MembershipType { get; set; }
    }
}
