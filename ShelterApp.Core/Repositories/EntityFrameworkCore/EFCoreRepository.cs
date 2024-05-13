using Microsoft.EntityFrameworkCore;
using ShelterApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Core.Repositories.EntityFrameworkCore
{
    public class EfCoreRepository<TEntity> : IEfCoreRepository<TEntity> where TEntity : class, IEntity, new()
    {

        private DbContext _dbContext;

        private DbSet<TEntity> _dbset;

        public EfCoreRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _dbset.SingleOrDefaultAsync(predicate);

            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = await WithDetailsAsync(includeProperties);

            if (predicate != null)
            {
                return await queryable.FirstOrDefaultAsync(predicate);
            }

            return await queryable.FirstOrDefaultAsync();

        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var entities = predicate == null ? await _dbset.ToListAsync() : await _dbset.Where(predicate).ToListAsync();

            return entities;
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {

            var queryable = await WithDetailsAsync(includeProperties);

            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            return await queryable.ToListAsync();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);

            return entity;
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await InsertAsync(entity);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.ChangeTracker.Clear();

            _dbContext.Attach(entity);

            var updatedEntity = _dbContext.Update(entity).Entity;

            return updatedEntity;
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await UpdateAsync(entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            //var entity = _dbset.Single(t => t.ID == id);
            var entity = _dbset.FirstOrDefault(t => t.ID == id);

            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
        }

        private static IQueryable<TEntity> IncludeDetails(IQueryable<TEntity> query, Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors != null)
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }

        public async Task<IQueryable<TEntity>> WithDetailsAsync(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return IncludeDetails(_dbset.AsQueryable(), propertySelectors);
        }

        public async Task<IQueryable<TEntity>> GetQueryableAsync()
        {
            await Task.CompletedTask;
            return _dbset.AsQueryable();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbset.AnyAsync(predicate);
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }

}
