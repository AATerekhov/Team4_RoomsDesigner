﻿using RoomsDesigner.Domain.Entity.Base;
using System.Linq.Expressions;

namespace RoomsDesigner.Domain.Repository.Abstractions
{
    public interface IRepository<TEntity, in TId> where TEntity : Entity<TId> where TId : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, string? includes = null, bool asNoTracking = false, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> filter, string? includes = null, bool asNoTracking = false, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
