////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Runtime.Serialization;
////using Accela.Mobile.ClientModel.Diagnostics;

////namespace Accela.Apps.Services.Models.Diagnostics
////{
////    [DataContract(Name = "logEntry")]
////    public class WSLogEntry
////    {
////        /// <summary>
////        /// Gets or sets entry id.
////        /// </summary>
////        [DataMember(Name = "id", EmitDefaultValue = false)]
////        public int Id
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets trace id.
////        /// </summary>
////        [DataMember(Name = "traceId", EmitDefaultValue = false)]
////        public string TraceId
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets order.
////        /// </summary>
////        [DataMember(Name = "order", EmitDefaultValue = false)]
////        public int Order
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets log level.
////        /// </summary>
////        [DataMember(Name = "logLevel", EmitDefaultValue = false)]
////        public string LogLevel
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets message.
////        /// </summary>
////        [DataMember(Name = "message", EmitDefaultValue = false)]
////        public string Message
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets detail.
////        /// </summary>
////        [DataMember(Name = "detail", EmitDefaultValue = false)]
////        public string Detail
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets detail size.
////        /// </summary>
////        [DataMember(Name = "detailSize", EmitDefaultValue = false)]
////        public int DetailSize
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets method name.
////        /// </summary>
////        [DataMember(Name = "methodName", EmitDefaultValue = false)]
////        public string MethodName
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets method duration time.
////        /// </summary>
////        [DataMember(Name = "methodElapsed", EmitDefaultValue = false)]
////        public int MethodElapsed
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets method input data size.
////        /// </summary>
////        [DataMember(Name = "methodInSize", EmitDefaultValue = false)]
////        public int MethodInSize
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets method output data size.
////        /// </summary>
////        [DataMember(Name = "methodOutSize", EmitDefaultValue = false)]
////        public int MethodOutSize
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets user id.
////        /// </summary>
////        [DataMember(Name = "userName", EmitDefaultValue = false)]
////        public string UserName
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets app name.
////        /// </summary>
////        [DataMember(Name = "appName", EmitDefaultValue = false)]
////        public string AppName
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets app ver.
////        /// </summary>
////        [DataMember(Name = "appVer", EmitDefaultValue = false)]
////        public string AppVer
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets environment ver.
////        /// </summary>
////        [DataMember(Name = "envName", EmitDefaultValue = false)]
////        public string EnvName
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets agency name.
////        /// </summary>
////        [DataMember(Name = "agency", EmitDefaultValue = false)]
////        public string AgencyName
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets the entity create date.
////        /// </summary>
////        [DataMember(Name = "dateCreated", EmitDefaultValue = false)]
////        public DateTime DateCreated
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Convert LogEntry to WSLogEntry.
////        /// </summary>
////        /// <param name="logEntry">LogEntry.</param>
////        /// <returns>WSLogEntry.</returns>
////        public static WSLogEntry FromEnitiy(LogEntry logEntry)
////        {
////            if (logEntry != null)
////            {
////                return new WSLogEntry()
////                {
////                    Id = logEntry.Id,
////                    TraceId = logEntry.TraceId,
////                    Order = logEntry.Order,
////                    LogLevel = logEntry.LogLevel,
////                    Message = logEntry.Message,
////                    Detail = logEntry.Detail,
////                    DetailSize = logEntry.DetailSize,
////                    MethodName = logEntry.MethodName,
////                    MethodElapsed = logEntry.MethodElapsed,
////                    MethodInSize = logEntry.MethodInSize,
////                    MethodOutSize = logEntry.MethodOutSize,
////                    UserName = logEntry.UserName,
////                    AppName = logEntry.AppName,
////                    AppVer = logEntry.AppVer,
////                    EnvName = logEntry.EnvName,
////                    AgencyName = logEntry.AgencyName,
////                    DateCreated = logEntry.DateCreated
////                };
////            }
////            return null;
////        }
////    }
////}
