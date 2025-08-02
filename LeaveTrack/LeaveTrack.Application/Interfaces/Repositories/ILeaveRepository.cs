
using LeaveTrack.Application.RequestObjects;
using LeaveTrack.Application.ViewModels;
using LeaveTrack.Domain.Entities;

namespace LeaveTrack.Application.Interfaces.Repositories
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        public Task<IEnumerable<Leave>> GetAllLeavesByUserId(int id);
        public Task<List<Leave>> GetAllWithIncludesAsync();
        public Task<List<Leave>> GetFilteredListAsync(FilterRequest filterRequest);
        public Task<int> GetYearlyCountForEmployeeAsync(int employeeId);
        public Task<int> GetUpcomingLeaveCountAsync();
        public Task<List<int>> GetMonthlyLeaveCountAsync(int year);
        public Task<List<Employee?>> GetActiveInLeaveEmployeeAsync();
    }
}
