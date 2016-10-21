using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests
{
    [DataContract]
    public class AuthenticateUserRequest : RequestBase
    {
        /// <summary>
        /// Agency that setting in cloud service
        /// </summary>
        [DataMember(Name = "agency", EmitDefaultValue = false)]
        public string Agency { get; set; }

        [DataMember(Name = "userName", EmitDefaultValue = false)]
        public string LoginName { get; set; }

        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        [DataMember(Name = "environmentName", EmitDefaultValue = false)]
        public string EnvironmentName { get; set; }

        [DataMember(Name = "appID", EmitDefaultValue = false)]
        public string AppID { get; set; }

        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string Version { get; set; }

        [DataMember(Name = "deviceId", EmitDefaultValue = false)]
        public string DeviceID { get; set; }

        [DataMember(Name = "deviceType", EmitDefaultValue = false)]
        public string DeviceType { get; set; }
    }
}
