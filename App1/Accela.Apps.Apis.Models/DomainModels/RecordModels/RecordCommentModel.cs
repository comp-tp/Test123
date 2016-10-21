using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    [DataContract]
    public class RecordCommentModel : ActionDataModel
    {
        /// <summary>
        /// Gets or Sets the RecordCommentModel Key.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// Gets or Sets the UserId.
        /// </summary>
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or Sets the IdentifierDisplay.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or Sets the Comments.
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or Sets the Date.
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or Sets the ShowOnInspection.
        /// </summary>
        [DataMember(Name = "showOnInspection", EmitDefaultValue = false)]
        public bool? ShowOnInspection { get; set; }

    }
}
