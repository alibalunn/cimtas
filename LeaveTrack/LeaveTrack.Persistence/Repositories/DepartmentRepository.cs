using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.ViewModels;
using LeaveTrack.Domain.Entities;
using LeaveTrack.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeaveTrack.Persistence.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<DepartmentLeaveDetailsViewModel?> GetDepartmentWithEmployeesAsync(int id)
        {
            return await Table
                .Where(d => d.Id == id)
                .Include(d => d.Employees)
                .Select(d => new DepartmentLeaveDetailsViewModel
                {
                    Employees = d.Employees
                    .Select(e => new EmployeeViewModel { Id = e.Id, AnnualLeaveLimit = e.AnnualLeaveLimit, FullName = e.FullName })
                    .ToList(),
                }).FirstOrDefaultAsync();
        }
    }
}
