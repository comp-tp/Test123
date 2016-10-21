using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Response
{
    [DataContract(Name = "authResponse")]
    public class CitizenUserAuthenticateResponse : ResponseBase
    {
        [DataMember(EmitDefaultValue = false)]
        public string result { get; set; }
    }
}