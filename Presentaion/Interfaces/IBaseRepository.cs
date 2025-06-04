﻿using Presentaion.Models;
using System.Linq.Expressions;

namespace Presentaion.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<RepoResult> AddAsync(TEntity entity);
        Task<RepoResult> DeleteAsync(TEntity entity);
        Task<RepoResult> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<RepoResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<RepoResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<RepoResult> UpdateAsync(TEntity entity);
    }
}