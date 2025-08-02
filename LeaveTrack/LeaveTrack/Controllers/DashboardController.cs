using LeaveTrack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveTrack.Controllers
{
    [Route("dashboard")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var details = await _service.GetDashboardDetailsAsync();
            var username = User.Identity?.Name;

            
            ViewBag.Username = username;

            return View(details);
        }
    }
}
