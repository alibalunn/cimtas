using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Domain.Entities;
using LeaveTrack.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LeaveTrack.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> GetDepartmentNameByUserIdAsync(int id)
        {
            var findedEmployee = await Table
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);

            return findedEmployee?.Department?.Name ?? "Bulunamadı";
        }

        public async Task<Employee?> GetEmployeeByUsernameAsync(string username)
            => await Table.FirstOrDefaultAsync(e => e.Username == username);

        public async Task<Employee?> GetEmployeeWithDetailsAsync(string username)
        {
            var employeeDetails = await Table.Where(e => e.Username == username)
                .Include(e => e.Leaves)
                .Include(e => e.Department)
                .FirstOrDefaultAsync();

            return employeeDetails;
        }
        public async Task<Employee?> GetEmployeeWithDetailsAsync(int id)
        {
            var employeeDetails = await Table.Where(e => e.Id == id)
                .Include(e => e.Leaves)
                .Include(e => e.Department)
                .FirstOrDefaultAsync();

            return employeeDetails;
        }
    }
}
