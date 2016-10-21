using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Diagnostics
{
    [DataContract(Name = "createLogRequest")]
    public class WSCreateLogRequest
    {
        /// <summary>
        /// Gets or sets trace id.
        /// </summary>
        [DataMember(Name = "traceId", EmitDefaultValue = false)]
        public string TraceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets log level.
        /// </summary>
        [DataMember(Name = "logLevel", EmitDefaultValue = false)]
        public string LogLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets detail.
        /// </summary>
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public string Detail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets method name.
        /// </summary>
        [DataMember(Name = "methodName", EmitDefaultValue = false)]
        public string MethodName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets method duration time.
        /// </summary>
        [DataMember(Name = "methodElapsed", EmitDefaultValue = false)]
        public int MethodElapsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember(Name = "userName", EmitDefaultValue = false)]
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets app name.
        /// </summary>
        [DataMember(Name = "appName", EmitDefaultValue = false)]
        public string AppName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets app ver.
        /// </summary>
        [DataMember(Name = "appVer", EmitDefaultValue = false)]
        public string AppVer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets environment name.
        /// </summary>
        [DataMember(Name = "envName", EmitDefaultValue = false)]
        public string EnvName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets agency name.
        /// </summary>
        [DataMember(Name = "agency", EmitDefaultValue = false)]
        public string AgencyName
        {
            get;
            set;
        }
    }
}
