using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.Interfaces.Services;
using LeaveTrack.Persistence.Repositories;
using LeaveTrack.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveTrack.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<ILeaveSettingsRepository, LeaveSettingsRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILeaveService, LeaveService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
