using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Domain.Entities;
using LeaveTrack.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeaveTrack.Persistence.Repositories
{
    public class LeaveSettingsRepository : Repository<LeaveSettings>, ILeaveSettingsRepository
    {
        public LeaveSettingsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<int> GetCurrentLeaveCountasync()
            => (await Table.FirstOrDefaultAsync()).AnnualLeaveLimit;
    }
}
