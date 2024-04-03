﻿namespace Konsom.DAL.Repository
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<T?> GetValue(Guid? id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}