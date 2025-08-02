using LeaveTrack.Application.RequestObjects;
using LeaveTrack.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveTrack.Controllers
{
    [Route("admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public AdminController()
        {
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult Index(DepartmentRequest model)
        {
            if (!ModelState.IsValid)
            {
                var adminPanelModel = new AdminPanelViewModel
                {
                    Department = model,
                };

                return View("Index", adminPanelModel);
            }

            return RedirectToAction("Index");
        }
    }
}
