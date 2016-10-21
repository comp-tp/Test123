using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.WSModels
{
    [DataContract()]
    [Serializable]
    public class GenericResultResponse<T> : WSResponseBase
    {
        public GenericResultResponse()
        {
            // default status 200 - OK
            Status = 200;
        }

        /// <summary>
        /// Http Status. one of HttpStatusCode enum.
        /// </summary>
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "result", EmitDefaultValue = false)]
        public T Result { get; set; }


        /// <summary>
        /// Response error code if any
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Response message
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// More details
        /// </summary>
        [DataMember(Name = "more", EmitDefaultValue = false)]
        public string More
        {
            get;
            set;
        }

        /// <summary>
        /// Trace Id
        /// </summary>
        [DataMember(Name = "traceId", EmitDefaultValue = false)]
        public string TraceId
        {
            get;
            set;
        }
    }
}
