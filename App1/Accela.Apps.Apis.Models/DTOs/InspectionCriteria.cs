using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using System;

namespace Accela.Apps.Apis.Models.DTOs
{
    /// <summary>
    /// Criteria for query inspection
    /// </summary>
    [DataContract]
    public class InspectionCriteria
    {
        /// <summary>
        /// This field caches inspector keys.
        /// </summary>
        [DataMember(Name = "inspectorIds")]
        public List<string> InspectorIds { get; set; }

        /// <summary>
        /// Gets or sets InspectionIds
        /// </summary>
        [DataMember(Name = "insepctionId")]
        public string InspectionId { get; set; }

        /// <summary>
        /// Record ids
        /// </summary>
        [DataMember(Name = "recordId")]
        public string RecordId { get; set; }
         
        /// <summary>
        /// only get open inspection (pending/scheduled) or not
        /// </summary>
        [DataMember(Name = "openInspectionsOnly")]
        public string OpenInspectionsOnly { get; set; }

        //[DataMember(Name = "resultTypes")]
        //public List<string> ResultTypes { get; set; }

        /// <summary>
        /// This field caches inspector keys.
        /// </summary>
        [DataMember(Name = "districts")]
        public List<string> Districts { get; set; }

        [DataMember(Name = "types")]
        public List<string> Types { get; set; }

        [DataMember(Name = "contacts")]
        public ContactModel Contacts { get; set; }

        [DataMember(Name = "address")]
        public AddressModel Address { get; set; }

        [DataMember(Name = "parcelId")]
        public string ParcelId { get; set; }

        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        [DataMember(Name = "recordTypeIds")]
        public List<string> RecordTypeIds { get; set; }

        public string ScheduleDateFrom { get; set; }

        public string ScheduleDateTo { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; } 
    }
}
