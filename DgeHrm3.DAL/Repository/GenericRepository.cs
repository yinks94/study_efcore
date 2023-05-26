using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

using DgeHrm3.DAL.Interfaces;
using DgeHrm3.DAL.Model;

namespace DgeHrm3.DAL.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{

    protected readonly IDataStoreContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public GenericRepository(IDataStoreContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public virtual IQueryable<TEntity> GetAll(bool asNoTracking = true)
    {
        if (asNoTracking)
            return _context.Set<TEntity>().AsNoTracking();
        else
            return _context.Set<TEntity>().AsQueryable();
    }

    public virtual IQueryable<TEntity> GetAllBySpec(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true)
    {
        if (asNoTracking)
            return _context.Set<TEntity>().Where(predicate).AsNoTracking();
        else
            return _context.Set<TEntity>().Where(predicate).AsQueryable();
    }

    public async virtual Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        return await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
    }

    public async virtual Task<TEntity?> GetBySpecAsync<Spec>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async virtual Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async virtual Task<ICollection<TEntity>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async virtual Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().CountAsync(cancellationToken);
    }

    public async virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().Where(predicate).CountAsync(cancellationToken);
    }

    public async virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
    }

    public async virtual Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().AnyAsync(cancellationToken);
    }

    public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> queryable = GetAll();
        foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
        {
            queryable = queryable.Include(includeProperty);
        }

        return queryable;
    }


    public virtual TEntity Add(TEntity entity)
    {
        return _context.Set<TEntity>().Add(entity).Entity;
    }

    public async virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual ICollection<TEntity> AddRange(ICollection<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);

        return entities;
    }

    public async virtual Task<int> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public async virtual Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Remove(entity);

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual void DeleteRange(ICollection<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }

    public async virtual Task<int> DeleteRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().RemoveRange(entities);

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }

    public async virtual Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Update(entity);

        return await _context.SaveChangesAsync(cancellationToken);
    }
        
}