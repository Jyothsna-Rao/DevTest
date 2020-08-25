using DataAccessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();

       Task<TEntity> AddAsync(TEntity entity);

       Task<TEntity> UpdateAsync(TEntity entity);

        TEntity GetById(Expression<Func<TEntity, bool>> match);
        IEnumerable<TEntity> Query();
    }
}
