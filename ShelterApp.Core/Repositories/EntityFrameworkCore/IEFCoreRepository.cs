using ShelterApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Core.Repositories.EntityFrameworkCore
{
    public interface IEfCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IQueryable<TEntity>> WithDetailsAsync(params Expression<Func<TEntity, object>>[] propertySelectors);
    }
}
