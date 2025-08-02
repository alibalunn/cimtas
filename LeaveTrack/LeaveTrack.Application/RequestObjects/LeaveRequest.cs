using LeaveTrack.Application.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.RequestObjects
{
    public class LeaveRequest
    {
        [Required(ErrorMessage = "Başlangıç Tarihi zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Lütfen tarih formatını doğru giriniz.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş Tarihi zorunludur.")]
        [DataType(DataType.Date, ErrorMessage = "Lütfen tarih formatını doğru giriniz.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Çalışan zorunludur.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçerli bir çalışan seçiniz.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "İzin Türü zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir izin türü seçiniz.")]
        public int LeaveTypeId { get; set; }

        [Required(ErrorMessage = "Departman zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir departman seçiniz.")]
        public int DepartmentId { get; set; }
    }
}
