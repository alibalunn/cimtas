using LeaveTrack.Domain.Entities;
using System.Threading.Tasks;

namespace LeaveTrack.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<Employee?> GetEmployeeWithDetailsAsync(string username);
        public Task<string> GetDepartmentNameByUserIdAsync(int id);
        public Task<Employee?> GetEmployeeWithDetailsAsync(int id);
        public Task<Employee?> GetEmployeeByUsernameAsync(string username);
    }
}
