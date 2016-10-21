using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Departments
{
    [DataContract(Name = "staff")]
    public class WSSystemStaff : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false, Order = 1)]
        public string Display { get; set; }

        [DataMember(Name = "firstName", EmitDefaultValue = false, Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName", EmitDefaultValue = false, Order = 3)]
        public string LastName { get; set; }
    }
}
