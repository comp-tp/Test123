using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Request.Record
{
    [DataContract(Name = "getRecordByIdRequest")]
    public class CitizenGetRecordByIdRequest : RequestBase
    {
        [DataMember]
        public string recordId
        {
            get;
            set;
        }
    }
}