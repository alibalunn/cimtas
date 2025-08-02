
namespace LeaveTrack.Application.ViewModels
{
    public class DashboardViewModel
    {
        public int YearlyTotalLeaveCount { get; set; }
        public int UpcomingLeaveCount { get; set; }
        public List<int> MonthlyLeaveCounts { get; set; } = new();
        public List<EmployeeViewModel> ActiveLeavesEmployees { get; set; } = new();
        public int TotalEmployeeCount { get; set; }
        public string LoggedInUserFullName { get; set; } = string.Empty;
    }

}
