using LeaveTrack.Application.Validators;
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.RequestObjects
{
    [MetadataType(typeof(LeaveSettingsMetaData))]
    public class LeaveSettingsRequest
    {
        public int AnnualLeaveLimit { get; set; }
    }
}
