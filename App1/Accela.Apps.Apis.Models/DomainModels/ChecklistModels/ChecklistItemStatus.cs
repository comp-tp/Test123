using System;
using System.Collections.Generic;
using System.Globalization;
//using Accela.Azure.Server.Toolkits.Persistences.DBAttribute;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ChecklistModels
{
    [DataContract]
    public class ChecklistItemStatus : DataModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the inspection status keys.
        /// </summary>
        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the inspection status diplay.
        /// </summary>
        [DataMember(Name = "display")]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the inspection statustype.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the default score string.
        /// </summary>
        /// <value>
        /// The default score string.
        /// </value>
        [DataMember(Name = "defaultScore")]
        public string DefaultScore { get; set; }

        #endregion Properties
    }

    [DataContract]
    public class ChecklistItemStatusGroup : DataModel
    {
        /// <summary>
        /// Gets or sets the inspection status keys.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the inspection status diplay.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the check list item statuses.
        /// </summary>
        [DataMember(Name = "checklistItemStatuses", EmitDefaultValue = false)]
        public List<ChecklistItemStatus> ChecklistItemStatuses { get; set; }
    }
}