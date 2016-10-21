using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses
{
    [DataContract(Name = "saveAppDataResponse")]
    public class DeleteAppDataResponse : ResponseBase
    {
        [DataMember(Name = "isDeleteSuccess")]
        public bool IsDeleteSuccess { get; set; }       
    }
}
