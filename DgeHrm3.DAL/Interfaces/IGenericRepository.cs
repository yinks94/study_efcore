
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using DgeHrm3.DAL.Model;

namespace DgeHrm3.DAL.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : class
{ 

    IUnitOfWork UnitOfWork
    {
        get;
    }

    TEntity Add(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    ICollection<TEntity> AddRange(ICollection<TEntity> entities);
    Task<int> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    void DeleteRange(ICollection<TEntity> entities);
    Task<int> DeleteRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    IQueryable<TEntity> GetAll(bool asNoTracking = true);
    IQueryable<TEntity> GetAllBySpec(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);
    Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
    Task<TEntity?> GetBySpecAsync<Spec>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<ICollection<TEntity>> ListAsync(CancellationToken cancellationToken = default);
    Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
}