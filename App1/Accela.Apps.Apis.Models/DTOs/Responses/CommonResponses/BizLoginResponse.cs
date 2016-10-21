using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses
{
    [DataContract(Name = "bizLoginResponse")]
    public class BizLoginResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the inspector identifier.
        /// </summary>
        /// <value>
        /// The inspector identifier.
        /// </value>
        [DataMember(Name = "inspectorIdentifier", EmitDefaultValue = false)]
        public string InspectorIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the state of the application.
        /// </summary>
        /// <value>
        /// The state of the application.
        /// </value>
        [DataMember(Name = "applicationState", EmitDefaultValue = false)]
        public string ApplicationState { get; set; }
    }
}
