using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses
{
    [DataContract(Name = "saveAppDataResponse")]
    public class SaveAppDataResponse : ResponseBase
    {
        [DataMember(Name = "isSaveSuccess")]
        public bool IsSaveSuccess { get; set; }        
    }
}
