using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AppDataRequests
{
    [DataContract(Name = "saveDataRequest")]
    public class SaveAppDataRequest : RequestBase
    {
        [DataMember(Name = "container")]
        public string Container { get; set; }

        [DataMember(Name = "blobName")]
        public string BlobName { get; set; }

        [DataMember(Name = "userId")]
        public string UserId { get; set; }

        [DataMember(Name = "appData")]
        public string AppData { get; set; }
    }
}
