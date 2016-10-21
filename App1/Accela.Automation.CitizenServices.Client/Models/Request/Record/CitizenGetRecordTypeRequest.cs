using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Request.Record
{
    [DataContract(Name = "recordTypeRequest")]
    public class CitizenGetRecordTypeRequest : RequestBase
    {
        [DataMember]
        public string module
        {
            get;
            set;
        }         
    }
}