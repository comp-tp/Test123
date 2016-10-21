using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests
{
    public class SystemInfo
    {
        public string AppId { get; set; }
        public string Version { get; set; }
        public string Language { get; set; }
        public string DeviceId { get; set; }
        public string Token { get; set; }
    }
}
