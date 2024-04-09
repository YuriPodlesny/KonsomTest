namespace Konsom.Application.Interfaces
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAllAsync();
    }
}
