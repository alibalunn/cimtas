
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.Validators
{
    public class LeaveTypeMetaData
    {
        [Required(ErrorMessage = "İzin türü adı zorunludur.")]
        [StringLength(100, ErrorMessage = "İzin türü adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string? Description { get; set; }
    }
}
