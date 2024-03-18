using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test.Thunders.Domain.Base;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase<TEntity>
{
    DbSet<TEntity> GetDbSet();
    IQueryable<TEntity> GetDbSetQuery();
    Task<TEntity> FindAsync(Guid key);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    Task AddAsync(TEntity entity);
    Task AddListAsync(IEnumerable<TEntity> entities);
    Task UpdateListAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
}