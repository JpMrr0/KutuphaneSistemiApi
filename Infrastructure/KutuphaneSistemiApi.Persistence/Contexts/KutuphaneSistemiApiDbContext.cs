using KutuphaneSistemiApi.Domain.Entities;
using KutuphaneSistemiApi.Domain.Entities.Identity;
using KutuphaneSistemiApi.Domain.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Persistence.Contexts
{
    public class KutuphaneSistemiApiDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public KutuphaneSistemiApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
