using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests
{
    [DataContract]
    public class AppSettingRequest : RequestBase
    {
        public string AppId { get; set; }

        public string Agency;

        public string SettingKey { get; set; }
    }
}
