using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class LogonModel
    {
        /// <summary>
        /// Agency Name
        /// </summary>
        [DataMember(Name = "agency")]
        public string Agency { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Client Language and Region code "Ex: en-US, en-AU, cn etc". 
        /// </summary>
        [DataMember(Name = "language")]
        public string Language { get; set; }

        /// <summary>
        /// App Name (InspectorApp, CivicHero etc)
        /// </summary>
        [DataMember(Name = "appName")]
        public string AppName { get; set; }

        /// <summary>
        /// DeviceType (iPhone, iPad, AndroidPhone, WindowsPhone, WindowsTablet etc)
        /// </summary>
        [DataMember(Name = "deviceType")]
        public string DeviceType { get; set; }

        /// <summary>
        /// Unique Device Identifier
        /// </summary>
        [DataMember(Name = "deviceId")]
        public string DeviceId { get; set; }

        /// <summary>
        /// The environment.
        /// </summary>
        [DataMember(Name = "environmentName")]
        public string EnvironmentName { get; set; }

        ///// <summary>
        ///// Identity provider type: Agency, Live, Facebook, Yahoo, Google etc. 
        ///// </summary>
        //public string IdentityProvider { get; set; }
    }
}
