using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Inspections;

namespace Accela.Apps.Apis.WSModels.V1.Inspectors
{
    [DataContract]
    public class WSInspectorWithDepartment : WSInspector
    {
        /// <summary>
        /// Gets or sets the inspector.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public override string Display { get; set; }

        [DataMember(Name = "departmentId", EmitDefaultValue = false)]
        public string DepartmentId{get;set;}

        [DataMember(Name = "departmentName", EmitDefaultValue = false)]
        public string DepartmentName{get;set;}
    }
}
