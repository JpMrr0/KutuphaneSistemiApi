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
    public class MemberWriteRepository : WriteRepository<Member>, IMemberWriteRepository
    {
        public MemberWriteRepository(KutuphaneSistemiApiDbContext context) : base(context)
        {
        }
    }
}
