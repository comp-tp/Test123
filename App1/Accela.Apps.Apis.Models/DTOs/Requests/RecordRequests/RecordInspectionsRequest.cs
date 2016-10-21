using System;
using System.Text;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    [DataContract(Name = "getRecordInspectionsRequest")]
    public class RecordInspectionsRequest : PageListRequest
    {
        /// <summary>
        /// Gets or sets the record id.
        /// </summary>
        /// <value>
        /// The record id.
        /// </value>
        [DataMember(Name = "decordId")]
        public string RecordId { get; set; }

        /// <summary>
        /// Gets or sets the inspection scheduled date from.
        /// </summary>
        /// <value>
        /// The inspection scheduled date from.
        /// </value>
        [DataMember(Name = "inspectionScheduledDateFrom")]
        public string InspectionScheduledDateFrom { get; set; }

        /// <summary>
        /// Gets or sets the inspection scheduled date to.
        /// </summary>
        /// <value>
        /// The inspection scheduled date to.
        /// </value>
        [DataMember(Name = "inspectionScheduledDateTo")]
        public string InspectionScheduledDateTo { get; set; }

        /// <summary>
        /// only get open inspection (pending/scheduled) or not
        /// </summary>
        [DataMember(Name = "openInspectionsOnly")]
        public bool? OpenInspectionsOnly { get; set; }
    }
}
