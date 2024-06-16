using KutuphaneSistemiApi.Domain.Entities;
using KutuphaneSistemiApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Persistence.Contexts
{
    public class KutuphaneSistemiApiDbContext : DbContext
    {
        public KutuphaneSistemiApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
