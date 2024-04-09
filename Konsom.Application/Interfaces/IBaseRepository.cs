﻿namespace Konsom.Application.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<T?> GetById(Guid? id);
        Task<List<T>> GetAllAsync();
    }
}
