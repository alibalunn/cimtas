using LeaveTrack.Domain.Common.Enums;
using LeaveTrack.Domain.Entities;

namespace LeaveTrack.Application.ViewModels
{
    public class LeaveListViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string LeaveType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? TotalLeaveAmount { get; set; }
        public LeaveState LeaveState { get; set; }
    }
}
