using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models
{
    [DataContract]
    public class ResponseBase
    {
        [DataMember(Name = "responseStatus", EmitDefaultValue = false, Order = 1)]
        public ResponseStatus responseStatus
        {
            get;
            set;
        }
    }
}