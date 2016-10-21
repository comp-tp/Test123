using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses
{
    [DataContract(Name = "getAppDataResponse")]
    public class GetAppDataResponse : ResponseBase
    {
        [DataMember(Name = "appData")]
        public string AppData { get; set; }
    }
}
