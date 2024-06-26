﻿using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Domain.Entities.Common;
using KutuphaneSistemiApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly KutuphaneSistemiApiDbContext _context;
        public ReadRepository(KutuphaneSistemiApiDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = false)
        {
            if (tracking)
                return Table;
            else
                return Table.AsNoTracking();
        }

        public async Task<T> GetById(string id, bool tracking = false)
        {
            if (tracking)
                return await Table.FindAsync(Guid.Parse(id));
            else
                return await Table.AsNoTracking().FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> model, bool tracking = false)
        {
            if(tracking)
                return Table.Where(model);
            else
                return Table.Where(model).AsNoTracking();
        }
    }
}
