using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels;
using System;

namespace Accela.Apps.Apis.Models.DTOs
{
    /// <summary>
    /// Response base
    /// </summary>
    [Serializable]
    [DataContract(Name = "response")]
    public class ResponseBase
    {
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        [DataMember(Name = "events", EmitDefaultValue = false)]
        public List<EventMessage> Events
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [DataMember(Name = "error", EmitDefaultValue = false)]
        public ErrorMessage Error
        {
            get;
            set;
        }
    }
}
