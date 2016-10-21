using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.WSModels
{
    [Serializable]
    [DataContract]
    public class BizServerResponseStatus
    {
        /// <summary>
        /// Http Status. one of HttpStatusCode enum.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string status
        {
            get;
            set;
        }

        /// <summary>
        /// Detail info.
        /// </summary>
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public DetailInfo detail
        {
            get;
            set;
        }
    }

    /// <summary>
    /// System info detail class.
    /// </summary>
    [Serializable]
    [DataContract(Name = "detail")]
    public class DetailInfo
    {
        /// <summary>
        /// Code.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string code
        {
            get;
            set;
        }

        /// <summary>
        /// Message.
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string message
        {
            get;
            set;
        }

        /// <summary>
        /// More detail.
        /// </summary>
        [DataMember(Name = "more", EmitDefaultValue = false)]
        public string more
        {
            get;
            set;
        }

        /// <summary>
        /// Trace ID.
        /// </summary>
        [DataMember(Name = "traceid", EmitDefaultValue = false)]
        public string traceid
        {
            get;
            set;
        }
    }
}
