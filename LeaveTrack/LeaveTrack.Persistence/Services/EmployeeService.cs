
using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.Interfaces.Services;
using LeaveTrack.Application.ViewModels;

namespace LeaveTrack.Persistence.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllAsync()
        {
            var allEmployes = await _repository.GetAllAsync();
            var employeeViewModels = allEmployes.Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                FullName = e.FullName,
                AnnualLeaveLimit = e.AnnualLeaveLimit
            });

            return employeeViewModels;
        }
    }
}
