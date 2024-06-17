using KutuphaneSistemiApi.Domain.Entities.Common;
using KutuphaneSistemiApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Domain.Entities
{
    public class Member : BaseEntity
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public MembershipTypes MembershipType { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
