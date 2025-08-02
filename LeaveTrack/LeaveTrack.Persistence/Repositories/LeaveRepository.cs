
using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.RequestObjects;
using LeaveTrack.Domain.Entities;
using LeaveTrack.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeaveTrack.Persistence.Repositories
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {
        private readonly ILeaveSettingsRepository _leaveSettingsRepository;
        public LeaveRepository(
            AppDbContext context,
            ILeaveSettingsRepository leaveSettingsRepository) : base(context)
        {
            _leaveSettingsRepository = leaveSettingsRepository;
        }

        public async Task<IEnumerable<Leave>> GetAllLeavesByUserId(int id)
        {
            return await Table
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .Where(l => l.EmployeeId == id)
                .ToListAsync();
        }

        public async Task<List<Leave>> GetAllWithIncludesAsync()
        {
            return await Table
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .ToListAsync();
        }

        public async Task<List<Leave>> GetFilteredListAsync(FilterRequest filterRequest)
        {
            var dynamicQuery = Table
                .Include(l => l.Employee)
                .ThenInclude(l => l.Department)
                .Include(l => l.LeaveType)
                .AsQueryable();

            if (filterRequest.StartDate.HasValue)
                dynamicQuery = dynamicQuery.Where(l => l.StartDate >= filterRequest.StartDate.Value);

            if (filterRequest.EndDate.HasValue)
                dynamicQuery = dynamicQuery.Where(l => l.EndDate <= filterRequest.EndDate.Value);

            if (!string.IsNullOrEmpty(filterRequest.Search))
                dynamicQuery = dynamicQuery.Where(e => e.Employee.FullName.Contains(filterRequest.Search));

            if (filterRequest.DepartmentId.HasValue)
                dynamicQuery = dynamicQuery.Where(l => l.Employee.DepartmentId == filterRequest.DepartmentId);

            return await dynamicQuery.ToListAsync();
        }

        public async Task<int> GetYearlyCountForEmployeeAsync(int employeeId)
        {
            int currentYear = DateTime.Now.Year;
            var startDateYear = new DateTime(currentYear, 1, 1);
            var nextYear = new DateTime(currentYear + 1, 1, 1);

            var leaves = await Table
                .Where(l => l.EmployeeId == employeeId &&
                            l.StartDate >= startDateYear && l.StartDate < nextYear)
                .ToListAsync();

            int totalDays = leaves.Sum(l => (l.EndDate - l.StartDate).Days + 1);

            return totalDays;
        }

        public async Task<int> GetUpcomingLeaveCountAsync()
        {
            var currentDate = DateTime.Now;

            return await Table
                .Where(l => l.StartDate > currentDate)
                .CountAsync();
        }

        public async Task<List<int>> GetMonthlyLeaveCountAsync(int year)
        {
            var startDate = new DateTime(year, 1, 1);
            var nextYear = new DateTime(year + 1, 1, 1);

            var monthlyGroupedItems = await Table
                .Where(l => l.StartDate >= startDate && l.StartDate < nextYear)
                .GroupBy(l => l.StartDate.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Count = g.Count(),
                }).ToListAsync();

            var monthlyCount = new int[12];

            foreach (var item in monthlyGroupedItems)
            {
                monthlyCount[item.Month - 1] = item.Count;
            }

            return monthlyCount.ToList();
        }

        public async Task<List<Employee?>> GetActiveInLeaveEmployeeAsync()
        {
            var currentDate = DateTime.Now;

            return await Table
                .Include(l => l.Employee)
                .Where(l => l.StartDate < currentDate && l.EndDate > currentDate)
                .Select(l => l.Employee)
                .Distinct()
                .Take(4)
                .ToListAsync();
        }
    }
}
