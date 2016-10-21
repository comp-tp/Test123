using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Request
{
    [DataContract(Name = "authRequest")]
    public class CitizenUserAuthenticateRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets serv provider code.
        /// </summary>
        [DataMember(Name = "agency", EmitDefaultValue = false)]
        public string agency { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string userId { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string password { get; set; }
    }
}