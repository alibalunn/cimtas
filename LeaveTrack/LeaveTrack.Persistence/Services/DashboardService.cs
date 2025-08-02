
using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.Interfaces.Services;
using LeaveTrack.Application.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LeaveTrack.Persistence.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveSettingsRepository _leaveSettingsRepository;
        public DashboardService(
            ILeaveRepository leaveRepository,
            IEmployeeRepository employeeRepository,
            ILeaveSettingsRepository leaveSettingsRepository)
        {
            _leaveRepository = leaveRepository;
            _employeeRepository = employeeRepository;
            _leaveSettingsRepository = leaveSettingsRepository;
        }

        public async Task<DashboardViewModel> GetDashboardDetailsAsync()
        {
            int currentYear = DateTime.Now.Year;

            int upcomingLeaveCount = await _leaveRepository.GetUpcomingLeaveCountAsync();
            var monthlyLeaveCount = await _leaveRepository.GetMonthlyLeaveCountAsync(currentYear);
            var activeInLeaveEmployee = await _leaveRepository.GetActiveInLeaveEmployeeAsync();
            int totalEmployeeCount = await _employeeRepository.GetAllAsQuaryable().CountAsync();

            var activeEmployeeViewModels = new List<EmployeeViewModel>();
            int yearlyTotalLeaveCount = 0;

            foreach (var employee in activeInLeaveEmployee)
            {
                int yearlyLeaveDays = await _leaveRepository.GetYearlyCountForEmployeeAsync(employee.Id);

                activeEmployeeViewModels.Add(new EmployeeViewModel
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    AnnualLeaveLimit = yearlyLeaveDays
                });

                yearlyTotalLeaveCount += yearlyLeaveDays;
            }

            return new DashboardViewModel
            {
                ActiveLeavesEmployees = activeEmployeeViewModels,
                UpcomingLeaveCount = upcomingLeaveCount,
                YearlyTotalLeaveCount = yearlyTotalLeaveCount,
                MonthlyLeaveCounts = monthlyLeaveCount,
                LoggedInUserFullName = "Deneme user",
                TotalEmployeeCount = totalEmployeeCount
            };
        }

    }
}
