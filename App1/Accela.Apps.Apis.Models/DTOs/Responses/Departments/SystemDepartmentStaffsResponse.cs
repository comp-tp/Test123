using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.Departments
{
    [DataContract]
    public class SystemDepartmentStaffsResponse : PagedResponse
    {
        [DataMember(Name = "staffs", EmitDefaultValue = false)]
        public List<StaffPersonModel> Staffs { get; set; }
    }
}
