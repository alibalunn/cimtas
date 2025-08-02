using LeaveTrack.Application.RequestObjects;

namespace LeaveTrack.Application.ViewModels
{
    public class LeaveViewModel
    {
        public LeaveRequest LeaveRequest { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
        public List<DepartmentViewModel> Departments { get; set; }
        public List<LeaveTypeViewModel> LeaveTypes { get; set; }
    }
}
