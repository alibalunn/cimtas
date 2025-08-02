using LeaveTrack.Application.ViewModels;

namespace LeaveTrack.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeViewModel>> GetAllAsync();
    }
}
