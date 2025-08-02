
using LeaveTrack.Application.Validators;
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.RequestObjects
{
    [MetadataType(typeof(LeaveTypeMetaData))]
    public class LeaveTypeRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
