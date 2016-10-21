using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class AALogonModel
    {
        /// <summary>
        /// Agency Name
        /// </summary>
        [DataMember(Name = "agency")]
        public string Agency { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [DataMember(Name = "loginName")]
        public string LoginName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
