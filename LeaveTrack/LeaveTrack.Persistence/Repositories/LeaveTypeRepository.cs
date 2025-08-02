
using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Domain.Entities;
using LeaveTrack.Persistence.Contexts;

namespace LeaveTrack.Persistence.Repositories
{
    public class LeaveTypeRepository : Repository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
