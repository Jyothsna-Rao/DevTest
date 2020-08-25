using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DevTestContext _dbContext;
        public Repository()
        {

        }
        public Repository(DevTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbContext.Set<TEntity>().AsEnumerable();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public  TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return _dbContext.Set<TEntity>().SingleOrDefault(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't retrieve entity");
            }
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public IEnumerable<TEntity> Query()
        {
            try
            {
                return _dbContext.Set<TEntity>().AsQueryable();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
            
        }
    }
}
