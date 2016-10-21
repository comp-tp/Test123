using System;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels
{
    [Serializable]
    [DataContract]
    public class EventMessage
    {
        [DataMember(Name="eventCode")]
        public string EventCode { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "detailInfo")]
        public string DetailInfo { get; set; }        
    }

    [Serializable]
    [DataContract]
    public class ErrorMessage
    {
        [DataMember(Name = "errorCode")]
        public string ErrorCode { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "detailInfo")]
        public string DetailInfo { get; set; }

        /// <summary>
        /// The field will get how to processing the bugs from xml file later
        /// Some knows bugs, we can show the resolution to user and let them check first
        /// </summary>
        [DataMember(Name = "resolution")]
        public string Resolution { get; set; }
    }
}
