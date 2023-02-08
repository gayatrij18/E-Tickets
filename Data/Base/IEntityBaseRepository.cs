﻿using System.Linq.Expressions;

namespace E_Tickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);
        Task UpdateAsync(int actorId, T entity);
        Task DeleteAsync(int actorId);
    }
}
