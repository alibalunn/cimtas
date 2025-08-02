using LeaveTrack.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.Validators
{
    public class DepartmentRequestMetaData
    {
        [Required(ErrorMessage = "Departman adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Departman adı en fazla 50 karakter olabilir.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string? Description { get; set; }
    }
}
