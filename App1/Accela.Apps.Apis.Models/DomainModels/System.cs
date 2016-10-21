using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels
{
    /// <summary>
    /// System info class.
    /// </summary>
    [DataContract(Name="system")]
    public class System
    {
        /// <summary>
        /// Http Status. one of HttpStatusCode enum.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// Detail info.
        /// </summary>
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public DetailInfo Detail
        {
            get;
            set;
        }
    }

    /// <summary>
    /// System info detail class.
    /// </summary>
    [DataContract(Name="detail")]
    public class DetailInfo
    {
        /// <summary>
        /// Detail code.
        /// </summary>
        public enum DetailCode
        {
            BadRequest = 1001,
            Forbidden = 1003,
            NotFound = 1004,
            InternalError = 1005
        }

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
        /// Messsage.
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
