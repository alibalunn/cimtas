using LeaveTrack.Application.RequestObjects;
using LeaveTrack.Application.ViewModels;

namespace LeaveTrack.Application.Interfaces.Services
{
    public interface ILeaveService
    {
        public Task<EmployeeLeaveDetailsViewModel> GetEmployeeLeaveDetailsAsync(int id);
        public Task<DepartmentLeaveDetailsViewModel> GetDepartmentLeaveDetailsAsync(int id);
        public Task<LeaveViewModel> GetLeavePageDropdownModelsAsync();
        public Task SaveLeaveAsync(LeaveRequest requestModel);
        public Task<IEnumerable<LeaveListViewModel>> GetLeaveViewModelsAsync();
        public Task<IEnumerable<LeaveListViewModel>> GetFilteredLeaveViewModelAsync(FilterRequest filter);
    }
}
