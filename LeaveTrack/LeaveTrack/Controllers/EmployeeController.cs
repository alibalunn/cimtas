using LeaveTrack.Application.Interfaces.Services;
using LeaveTrack.Application.ViewModels;
using LeaveTrack.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveTrack.Controllers
{
    [Route("employee")]
    [Authorize(Roles = "Admin, User")]
    public class EmployeeController : Controller
    {
        private readonly ILeaveService _leaveService;
        public EmployeeController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet("details/{id:int}")]
        [ServiceFilter(typeof(GlobalErrorExceptionFilter))]
        public async Task<IActionResult> Details([FromRoute]int id)
        {
            var leaveDetails = await _leaveService.GetEmployeeLeaveDetailsAsync(id);

            return Ok(new JsonResponse<EmployeeLeaveDetailsViewModel>
            {
                IsSuccess = true,
                Message = "Başarılı bir şekilde getirildi.",
                Data = leaveDetails,
            });
        }
    }
}
