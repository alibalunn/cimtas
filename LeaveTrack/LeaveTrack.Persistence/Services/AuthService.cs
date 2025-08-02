using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.Interfaces.Services;

namespace LeaveTrack.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public AuthService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<(bool IsValid, string? Role)> ValidateUserAsync(string username, string password)
        {
            var employee = await _employeeRepository.GetEmployeeByUsernameAsync(username);

            if (employee == null)
                return (false, null);

            if (!employee.IsSystemUser)
                return (false, null);

            if (employee.PasswordHash != password)
                return (false, null);

            return (true, employee.Role.ToString());
        }
    }
}
