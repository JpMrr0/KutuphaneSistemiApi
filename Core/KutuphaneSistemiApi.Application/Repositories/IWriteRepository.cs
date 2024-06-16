using KutuphaneSistemiApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Delete(T entity);
        bool DeleteRange(List<T> entities);
        Task<bool> DeleteById(string id);
        Task<int> SaveAsync();
    }
}
