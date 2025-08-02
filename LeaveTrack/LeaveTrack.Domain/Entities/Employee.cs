using LeaveTrack.Domain.Common.Enums;

namespace LeaveTrack.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public bool IsSystemUser { get; set; }
        public Role? Role { get; set; }
        public ICollection<Leave> Leaves { get; set; } = new List<Leave>();


        public string FullName { get; set; }
        public int? AnnualLeaveLimit { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
