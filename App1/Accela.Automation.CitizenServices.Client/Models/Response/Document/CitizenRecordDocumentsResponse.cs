using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Response.Document
{
    [DataContract]
    public class CitizenRecordDocumentsResponse : ResponseBase
    {
        [DataMember]
        public List<Accela.ACA.WSProxy.DocumentModel> result { get; set; }
    }
}