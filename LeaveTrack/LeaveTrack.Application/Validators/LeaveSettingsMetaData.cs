using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.Validators
{
    public class LeaveSettingsMetaData
    {
        [Range(1, 20, ErrorMessage = "Yıllık izin limiti 1 ile 20 arasında olmalıdır.")]
        public int AnnualLeaveLimit { get; set; }
    }
}
