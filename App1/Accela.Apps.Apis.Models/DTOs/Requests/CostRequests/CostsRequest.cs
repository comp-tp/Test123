using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.CostRequests
{
    /// <summary>
    /// CostsRequest class.
    /// </summary>
    [DataContract]
    public class CostsRequest : RequestBase
    {
        /// <summary>
        /// Record id.
        /// </summary>
        [DataMember(Name = "recordId")]
        public string RecordId
        {
            get;
            set;
        }
    }
}
