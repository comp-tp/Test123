using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests
{
    [DataContract]
    public class AppSettingsRequest : RequestBase
    {
        public string AppId { get; set; }
        
        public string Agency { get; set; }

        public string Host { get; set; }

        public List<string> SettingKeys { get; set; }
    }
}
