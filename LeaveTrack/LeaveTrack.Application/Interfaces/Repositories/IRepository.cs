
using LeaveTrack.Domain.Entities;

namespace LeaveTrack.Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        public Task<ICollection<T>> GetAllAsync(bool asNoTracking = false);
        public IQueryable<T> GetAllAsQuaryable();
        public Task<T> GetByIdAsync(int id);
        public Task<T?> RemoveByIdAsync(int id);
        public Task<int> AddAsync(T entity);
        public Task<T?> UpdateAsync(T entity);
        public Task<T?> UpdateByIdAsync(int id, T entity);
        public Task<bool> ExistsAsync(int id);
    }
}
