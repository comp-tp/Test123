using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    public class RelatedRecordsRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the identifier for the record to which the list of address belongs.
        /// </summary>
        public string RecordId { get; set; }
    }
}
