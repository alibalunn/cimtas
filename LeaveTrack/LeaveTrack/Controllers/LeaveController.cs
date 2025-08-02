using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.Interfaces.Services;
using LeaveTrack.Application.RequestObjects;
using LeaveTrack.Application.ViewModels;
using LeaveTrack.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Controllers
{
    [Route("leave")]
    [Authorize(Roles = "Admin,User")]
    public class LeaveController : Controller
    {
        private readonly ILeaveService _leaveService;
        private readonly IDepartmentRepository _departmentRepository;

        public LeaveController(ILeaveService leaveService, IDepartmentRepository departmentRepository)
        {
            _leaveService = leaveService;
            _departmentRepository = departmentRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> List([FromQuery] FilterRequest filter)
        {
            ViewBag.DepartmentList = await _departmentRepository.GetAllAsync();

            try
            {
                bool isFiltering = filter.StartDate.HasValue ||
                                   filter.EndDate.HasValue ||
                                   filter.DepartmentId.HasValue ||
                                   !string.IsNullOrEmpty(filter.Search);

                var model = isFiltering
                    ? await _leaveService.GetFilteredLeaveViewModelAsync(filter)
                    : await _leaveService.GetLeaveViewModelsAsync();

                return View(model);
            }
            catch (NotFoundException)
            {
                ModelState.AddModelError(string.Empty, "Sonuç bulunamadı.");
                return View(new List<LeaveListViewModel>());
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Beklenmeyen bir hata oluştu.");
                return View(new List<LeaveListViewModel>());
            }
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddNewLeave()
        {
            var leavePageDropdownItems = await _leaveService.GetLeavePageDropdownModelsAsync();
            return View(leavePageDropdownItems);
        }

        [HttpPost("add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewLeave([FromForm] LeaveRequest leaveRequest)
        {
            if (!ModelState.IsValid)
            {
                var leavesDropdown = await _leaveService.GetLeavePageDropdownModelsAsync();
                return View(leavesDropdown);
            }

            try
            {
                await _leaveService.SaveLeaveAsync(leaveRequest);
                return RedirectToAction(nameof(List));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Beklenmeyen bir hata oluştu.");
            }

            var dropdowns = await _leaveService.GetLeavePageDropdownModelsAsync();
            return View(dropdowns);
        }
    }
}
