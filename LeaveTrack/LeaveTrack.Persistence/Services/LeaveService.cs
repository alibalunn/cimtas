using LeaveTrack.Application.Interfaces.Repositories;
using LeaveTrack.Application.Interfaces.Services;
using LeaveTrack.Application.RequestObjects;
using LeaveTrack.Application.ViewModels;
using LeaveTrack.Domain.Common.Helpers;
using LeaveTrack.Domain.Entities;
using LeaveTrack.Domain.Exceptions;
using LeaveTrack.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Persistence.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveSettingsRepository _leaveSettingsRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRepository _repository;
        public LeaveService(
            IEmployeeRepository employeeRepository, 
            ILeaveSettingsRepository leaveSettingsRepository,
            IDepartmentRepository departmentRepository,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveRepository repository)
        {
            _employeeRepository = employeeRepository;
            _leaveSettingsRepository = leaveSettingsRepository;
            _departmentRepository = departmentRepository;   
            _leaveTypeRepository = leaveTypeRepository;
            _repository = repository;
        }

        public async Task<DepartmentLeaveDetailsViewModel> GetDepartmentLeaveDetailsAsync(int id)
        {
            if (id == 0)
            {
                var allEmployees = await _employeeRepository.GetAllAsync();

                return new DepartmentLeaveDetailsViewModel
                {
                    Employees = allEmployees.Select(e => new EmployeeViewModel
                    {
                        Id = e.Id,
                        FullName = e.FullName,
                        AnnualLeaveLimit = e.AnnualLeaveLimit
                    }).ToList()
                };
            }

            var departmentEmployees = await _departmentRepository.GetDepartmentWithEmployeesAsync(id);

            if (departmentEmployees == null)
                throw new NotFoundException("Departmana bağlı kullanıcı yok.");

            return departmentEmployees;
        }

        public async Task<EmployeeLeaveDetailsViewModel> GetEmployeeLeaveDetailsAsync(int id)
        {
            var employeeDetails = await _employeeRepository.GetEmployeeWithDetailsAsync(id);

            if (employeeDetails == null)
                throw new NotFoundException("Çalışan bulunamadı.");

            if (employeeDetails.Department == null)
                throw new BusinessException("Departman bilgisi yok.");

            int totalLeavesCount = await _leaveSettingsRepository.GetCurrentLeaveCountasync();

            var calculation = new EmployeeLeaveDetailsViewModel
            {
                DepartmentId = employeeDetails.Department.Id,
                DepartmentName = employeeDetails.Department.Name,
                LeaveAmount = LeaveCalculatorHelper.CalculateAnnualLeave(employeeDetails.Leaves, totalLeavesCount),
                TotalLeaveAmount = totalLeavesCount
            };

            return calculation;
        }

        public async Task<LeaveViewModel> GetLeavePageDropdownModelsAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var departments = await _departmentRepository.GetAllAsync();
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();

            return new LeaveViewModel
            {
                Departments = departments.Select(d => new DepartmentViewModel
                {
                    Description = d.Description,
                    Id = d.Id,
                    Name = d.Name,
                }).ToList(),
                Employees = employees.Select(e => new EmployeeViewModel
                {
                    AnnualLeaveLimit = e.AnnualLeaveLimit,
                    FullName = e.FullName,
                    Id = e.Id
                }).ToList(),
                LeaveTypes = leaveTypes.Select(lt => new LeaveTypeViewModel
                {
                    Id = lt.Id,
                    Description = lt.Description,
                    Name = lt.Name
                }).ToList()
            };
        }

        public async Task SaveLeaveAsync(LeaveRequest requestModel)
        {
            bool isExistsEmployee = await _employeeRepository.ExistsAsync(requestModel.EmployeeId);
            if (isExistsEmployee == false)
                throw new ValidationException("Çalışan bulunmadı.");

            bool isLeaveTypeExists = await _leaveTypeRepository.ExistsAsync(requestModel.LeaveTypeId);
            if (isLeaveTypeExists == false)
                throw new ValidationException("İzin türü geçersiz.");

            bool isDepartmentExists = await _departmentRepository.ExistsAsync(requestModel.DepartmentId);
            if (isDepartmentExists == false)
                throw new ValidationException("Departman bulunamadı.");

            var today = DateTime.Today;

            if (requestModel.StartDate < today)
                throw new ValidationException("Başlangıç tarihi bugün ve ilerisi olmalıdır.");

            if (requestModel.EndDate < requestModel.StartDate)
                throw new ValidationException("Bitiş tarihi, başlangıç tarihinden önce olamaz.");

            var employeeLeaveAmount = await _repository.GetAllLeavesByUserId(requestModel.EmployeeId);
            var systemTotalLeaveAmount = await _leaveSettingsRepository.GetCurrentLeaveCountasync();
            int employeeCalculatedLeaveAmount = LeaveCalculatorHelper.CalculateAnnualLeave(employeeLeaveAmount, systemTotalLeaveAmount);

            int targetLeaveAmount = LeaveCalculatorHelper.CalculateWithDates(requestModel.StartDate, requestModel.EndDate);

            if (targetLeaveAmount > systemTotalLeaveAmount)
                throw new ValidationException("Kullanıcı max izin limitini aştınız.");

            await _repository.AddAsync(new Leave
            {
                StartDate = requestModel.StartDate,
                EndDate = requestModel.EndDate,
                EmployeeId = requestModel.EmployeeId,
                LeaveTypeId = requestModel.LeaveTypeId,
                CreatedByUserId = 1 // todo will change as dynamic
            });
        }

        public async Task<IEnumerable<LeaveListViewModel>> GetLeaveViewModelsAsync()
        {
            var allLeaves = await _repository.GetAllWithIncludesAsync();

            if (allLeaves == null || !allLeaves.Any())
            {
                throw new NotFoundException("Geçmiş izin bulunamadı.");
            }

            var currentAnnualLeaveAmount = await _leaveSettingsRepository.GetCurrentLeaveCountasync();

            var result = new List<LeaveListViewModel>();

            foreach (var al in allLeaves)
            {
                var userLeaves = await _repository.GetAllLeavesByUserId(al.EmployeeId);
                var calculatedUserLeaveAmount = LeaveCalculatorHelper.CalculateAnnualLeave(userLeaves, currentAnnualLeaveAmount);
                string departmentName = await _employeeRepository.GetDepartmentNameByUserIdAsync(al.EmployeeId);

                var departmentDropdopdownList = await _departmentRepository.GetAllAsync();
                var departmentViewModels = departmentDropdopdownList.Select(dd => new DepartmentViewModel
                {
                    Description = dd.Description,
                    Id = dd.Id,
                    Name = dd.Name
                });

                result.Add(new LeaveListViewModel
                {
                    EmployeeId = al.EmployeeId,
                    EmployeeName = al.Employee.FullName,
                    StartDate = al.StartDate,
                    EndDate = al.EndDate,
                    LeaveType = al.LeaveType.Name,
                    TotalLeaveAmount = currentAnnualLeaveAmount - calculatedUserLeaveAmount,
                    DepartmentName = departmentName,
                    LeaveState = calculatedUserLeaveAmount + 5 > currentAnnualLeaveAmount ? LeaveState.High : LeaveState.Normal,
                });
            }

            return result;
        }

        public async Task<IEnumerable<LeaveListViewModel>> GetFilteredLeaveViewModelAsync(FilterRequest filter)
        {
            var filteredLeaves = await _repository.GetFilteredListAsync(filter);

            if (filteredLeaves == null || !filteredLeaves.Any())
                throw new NotFoundException("Sonuç bulunamadı.");

            var currentAnnualLeaveAmount = await _leaveSettingsRepository.GetCurrentLeaveCountasync();
            var result = new List<LeaveListViewModel>();

            foreach (var leave in filteredLeaves)
            {
                var userLeaves = await _repository.GetAllLeavesByUserId(leave.EmployeeId);
                var calculatedUserLeaveAmount = LeaveCalculatorHelper.CalculateAnnualLeave(userLeaves, currentAnnualLeaveAmount);
                string departmentName = await _employeeRepository.GetDepartmentNameByUserIdAsync(leave.EmployeeId);

                result.Add(new LeaveListViewModel
                {
                    EmployeeId = leave.EmployeeId,
                    EmployeeName = leave.Employee.FullName,
                    StartDate = leave.StartDate,
                    EndDate = leave.EndDate,
                    LeaveType = leave.LeaveType.Name,
                    TotalLeaveAmount = currentAnnualLeaveAmount - calculatedUserLeaveAmount,
                    DepartmentName = departmentName,
                    LeaveState = calculatedUserLeaveAmount + 5 > currentAnnualLeaveAmount ? LeaveState.High : LeaveState.Normal
                });
            }

            return result;
        }
    }
}
