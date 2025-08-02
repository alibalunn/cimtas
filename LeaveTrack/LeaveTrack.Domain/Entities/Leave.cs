namespace LeaveTrack.Domain.Entities
{
    public class Leave : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int CreatedByUserId { get; set; }
        public Employee? CreatedByUser { get; set; }
    }
}
