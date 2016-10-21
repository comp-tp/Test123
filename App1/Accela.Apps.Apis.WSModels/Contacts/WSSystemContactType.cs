using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Contacts
{
    [DataContract(Name = "contactType")]
    public class WSSystemContactType : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false, Order = 2)]
        public string Display { get; set; }
    }
}
