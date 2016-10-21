using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models
{
    [DataContract]
    public class GetDocumentContentResponse : ResponseBase
    {
        [DataMember]
        public Accela.ACA.WSProxy.DocumentModel result { get; set; }
    }
}