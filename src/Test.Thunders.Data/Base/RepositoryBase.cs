using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Thunders.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Test.Thunders.Data.Base;

public abstract class RepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity>
    where TEntity : EntityBase<TEntity>
    where TContext : DbContext
{
    private readonly DbSet<TEntity> _dbSet;

    protected RepositoryBase(TContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public virtual DbSet<TEntity> GetDbSet() => _dbSet;

    public virtual IQueryable<TEntity> GetDbSetQuery() => _dbSet?.AsNoTracking();

    public virtual async Task<TEntity> FindAsync(Guid key)
    {
        return await GetDbSet().FindAsync(key);
    }

    public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await GetDbSet().FirstOrDefaultAsync(expression);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await GetDbSet().AddAsync(entity);
    }

    public virtual async Task AddListAsync(IEnumerable<TEntity> entities)
    {
        await GetDbSet().AddRangeAsync(entities);
    }

    public virtual Task UpdateListAsync(IEnumerable<TEntity> entities)
    {
        GetDbSet().UpdateRange(entities);

        return Task.CompletedTask;
    }

    public virtual Task UpdateAsync(TEntity entity)
    {
        GetDbSet().Update(entity);

        return Task.CompletedTask;
    }

    public virtual Task RemoveAsync(TEntity entity)
    {
        GetDbSet().Remove(entity);

        return Task.CompletedTask;
    }

    public virtual Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        GetDbSet().RemoveRange(entities);

        return Task.CompletedTask;
    }
}