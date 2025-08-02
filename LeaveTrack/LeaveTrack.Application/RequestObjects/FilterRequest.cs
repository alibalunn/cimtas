namespace LeaveTrack.Application.RequestObjects
{
    public class FilterRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DepartmentId { get; set; }
        public string? Search { get; set; }
    }
}
