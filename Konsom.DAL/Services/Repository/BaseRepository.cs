using Konsom.Application.Interfaces;
using Konsom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Konsom.DAL.Services.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        private readonly ApplicationDBContext _db;

        public BaseRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public virtual async Task<bool> Create(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            T entity = await _db.Set<T>().FirstAsync(x => x.Id == id);
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetById(Guid? id)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
