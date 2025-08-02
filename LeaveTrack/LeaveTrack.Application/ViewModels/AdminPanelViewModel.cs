using LeaveTrack.Application.RequestObjects;
using LeaveTrack.Application.ViewModels;

namespace LeaveTrack.Application.ViewModels
{
    public class AdminPanelViewModel
    {
        public DepartmentRequest Department { get; set; } = new();
        public List<DepartmentViewModel> Departments { get; set; } = new();
        public LeaveSettingsRequest LeaveSettings { get; set; } = new();
        public LeaveTypeRequest LeaveType { get; set; } = new();
        public List<LeaveTypeViewModel> LeaveTypes { get; set; } = new();
    }
}
