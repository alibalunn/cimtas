using LeaveTrack.Application.ViewModels;
using LeaveTrack.Domain.Entities;

namespace LeaveTrack.Application.Interfaces.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        public Task<DepartmentLeaveDetailsViewModel?> GetDepartmentWithEmployeesAsync(int id);
    }
}
