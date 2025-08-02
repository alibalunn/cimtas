using System.Threading.Tasks;

namespace LeaveTrack.Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<(bool IsValid, string? Role)> ValidateUserAsync(string username, string password);
    }
}
