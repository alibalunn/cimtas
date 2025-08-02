using LeaveTrack.Application.Interfaces.Services;
using LeaveTrack.Application.ViewModels;
using LeaveTrack.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveTrack.Controllers
{
    [Route("department")]
    [Authorize(Roles = "Admin, User")]
    public class DepartmentController : Controller
    {
        private readonly ILeaveService _leaveService;
        public DepartmentController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet("employees/{id:int}")]
        [ServiceFilter(typeof(GlobalErrorExceptionFilter))]
        public async Task<IActionResult> GetEmployees([FromRoute]int id)
        {
            var employees = await _leaveService.GetDepartmentLeaveDetailsAsync(id);

            return Ok(new JsonResponse<DepartmentLeaveDetailsViewModel>
            {
                IsSuccess = true,
                Data = employees,
                Message = "Çalışanlar başarılı şekilde getirildi"
            });
        }
    }
}
