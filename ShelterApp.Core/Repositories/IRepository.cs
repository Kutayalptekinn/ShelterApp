using ShelterApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> InsertAsync(TEntity entity);

        Task InsertManyAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task UpdateManyAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(int id);

        Task<IQueryable<TEntity>> GetQueryableAsync();

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
