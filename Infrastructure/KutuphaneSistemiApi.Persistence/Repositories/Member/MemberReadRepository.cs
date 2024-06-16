using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Domain.Entities;
using KutuphaneSistemiApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Persistence.Repositories
{
    public class MemberReadRepository : ReadRepository<Member>, IMemberReadRepository
    {
        public MemberReadRepository(KutuphaneSistemiApiDbContext context) : base(context)
        {
        }
    }
}
