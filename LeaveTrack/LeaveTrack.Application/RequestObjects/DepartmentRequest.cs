using LeaveTrack.Application.Validators;
using System.ComponentModel.DataAnnotations;

namespace LeaveTrack.Application.RequestObjects
{
    [MetadataType(typeof(DepartmentRequestMetaData))]
    public class DepartmentRequest
    {
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
