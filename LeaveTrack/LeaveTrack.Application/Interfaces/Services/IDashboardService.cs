using LeaveTrack.Application.ViewModels;

namespace LeaveTrack.Application.Interfaces.Services
{
    public interface IDashboardService
    {
        public Task<DashboardViewModel> GetDashboardDetailsAsync();
    }
}
