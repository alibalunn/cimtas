using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Domain.Entities;
using LeaveTrack.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeaveTrack.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbSet<T> Table;
        protected readonly AppDbContext appDbContext;
        public Repository(AppDbContext context)
        {
            Table = context.Set<T>();
            appDbContext = context;
        }
        public async Task<int> AddAsync(T entity)
        {
            await Table.AddAsync(entity);

            return await appDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(bool asNoTracking = false)
            => asNoTracking ? await Table.AsNoTracking().ToListAsync() : await Table.ToListAsync();

        public Task<T> GetByIdAsync(int id)
            => Table.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<T?> RemoveByIdAsync(int id)
        {
            T? trackingData = null;
            T? entity = await GetAllAsQuaryable().FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                trackingData = Table.Remove(entity).Entity;
                await appDbContext.SaveChangesAsync();
            }

            return trackingData;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            var trackingData = Table.Update(entity).Entity;
            await appDbContext.SaveChangesAsync();

            return trackingData;
        }

        public async Task<T?> UpdateByIdAsync(int id, T entity)
        {
            var target = await GetByIdAsync(id);

            return target ?? null;
        }

        public IQueryable<T> GetAllAsQuaryable()
            => Table.AsQueryable<T>();

        public async Task<bool> ExistsAsync(int id)
            => await Table.AnyAsync(e => e.Id == id);
    }
}
