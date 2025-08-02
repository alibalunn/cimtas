using LeaveTrack.Domain.Entities;

namespace LeaveTrack.Domain.Common.Helpers
{
    public static class LeaveCalculatorHelper
    {
        public static int CalculateAnnualLeave(IEnumerable<Leave> leaves, int currentAnnualLeaveAmount)
        {
            int leaveAmount = 0;

            foreach (var leave in leaves)
            {
                var startDate = leave.StartDate.Date;
                var endDate = leave.EndDate.Date;

                leaveAmount += LeaveCalculatorHelper.CalculateWithDates(startDate, endDate);
            }

            return currentAnnualLeaveAmount - leaveAmount;
        }

        public static int CalculateWithDates(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1)
                .Select(x => startDate.AddDays(x))
                .Count(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday);
        }
    }
}
