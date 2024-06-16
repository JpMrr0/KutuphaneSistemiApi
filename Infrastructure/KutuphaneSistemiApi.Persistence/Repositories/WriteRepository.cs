using KutuphaneSistemiApi.Application.Repositories;
using KutuphaneSistemiApi.Domain.Entities.Common;
using KutuphaneSistemiApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly KutuphaneSistemiApiDbContext _context;
        public WriteRepository(KutuphaneSistemiApiDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entry = await Table.AddAsync(entity);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await Table.AddRangeAsync(entities);
            return entities.Count > 0;
        }

        public bool Delete(T entity)
        {
            var removeit = Table.Remove(entity);
            return removeit.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteById(string id)
        {
            var entity =  await Table.FirstAsync(p => p.Id == Guid.Parse(id));
            var removeit = Table.Remove(entity);
            return removeit.State == EntityState.Deleted;
        }

        public bool DeleteRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }
        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync() 
            => await _context.SaveChangesAsync();
    }
}
