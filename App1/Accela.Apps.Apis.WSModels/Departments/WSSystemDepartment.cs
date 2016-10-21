using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Departments
{
    [DataContract(Name = "department")]
    public class WSSystemDepartment : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false, Order = 1)]
        public string Display { get; set; }

        
    }
}
