using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Shared.WSModels;

namespace Accela.Apis.Service.Common
{
    [Serializable]
    [DataContract]
    public class AAResponseBase
    {
        /// <summary>
        /// System info.
        /// </summary>
        [DataMember(Name = "responseStatus", EmitDefaultValue = false, Order = 1)]
        public WSResponseStatus ResponseStatus
        {
            get;
            set;
        }
    }

    /// <summary>
    /// ResponseStatus
    /// </summary>
    [Serializable]
    [DataContract(Name = "responseStatus")]
    public class WSResponseStatus
    {
        /// <summary>
        /// Http Status. one of HttpStatusCode enum.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// Detail object.
        /// </summary>
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public WSResponseDetail Detail
        {
            get;
            set;
        }
    }

    [Serializable]
    [DataContract(Name = "detail")]
    public class WSResponseDetail
    {
        /// <summary>
        /// Code.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Message.
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// More detail.
        /// </summary>
        [DataMember(Name = "more", EmitDefaultValue = false)]
        public string More
        {
            get;
            set;
        }

        /// <summary>
        /// Trace ID.
        /// </summary>
        [DataMember(Name = "traceid", EmitDefaultValue = false)]
        public string TraceID
        {
            get;
            set;
        }
    }
}