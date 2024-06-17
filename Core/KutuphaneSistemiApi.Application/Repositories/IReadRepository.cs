using KutuphaneSistemiApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemiApi.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = false);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> model, bool tracking = false);
        Task<T> GetById(string id, bool tracking = false);
    }
}
