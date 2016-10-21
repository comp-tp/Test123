using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.Departments
{
    [DataContract]
    public class SystemDepartmentsResponse : PagedResponse
    {
        [DataMember(Name = "departments", EmitDefaultValue = false)]
        public List<SystemDepartmentModel> Departments { get; set; } 
    }
}
