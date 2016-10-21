using System;
//using Accela.Azure.Server.Toolkits.Persistences.DBAttribute;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ChecklistModels
{
    /// <summary>
    /// Checklist class
    /// </summary>
    [DataContract]
    public class ChecklistModel : ActionDataModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the checklist keys.
        /// It is primary keys for server side.
        /// if the property is null or empty, the mean the record is created by client and it didn't sync to server yet.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the checklist Subject.
        /// </summary>
        [DataMember(Name = "subject", EmitDefaultValue = false)]
        public string Subject { get; set; }

        [DataMember(Name = "checklistGroups", EmitDefaultValue = false)]
        public List<ChecklistGroupModel> ChecklistGroups { get; set; }

        /// <summary>
        /// The item is coresponse for id field in AMO
        /// </summary>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the total score string.
        /// </summary>
        /// <value>
        /// The total score string.
        /// </value>
        [DataMember(Name = "totalScore", EmitDefaultValue = false)]
        public string TotalScore { get; set; }

        /// <summary>
        /// Checklist Items
        /// The item only use to translate between client and server
        /// </summary>
        [DataMember(Name = "checklistItems", EmitDefaultValue = false)]
        public List<ChecklistItemModel> ChecklistItems { get; set; }

        #endregion Properties
    }
}
