
using LeaveTrack.Domain.Entities;

namespace LeaveTrack.Application.Interfaces.Repositories
{
    public interface ILeaveSettingsRepository : IRepository<LeaveSettings>
    {
        public Task<int> GetCurrentLeaveCountasync();
    }
}
