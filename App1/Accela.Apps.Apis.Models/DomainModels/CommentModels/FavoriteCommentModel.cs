using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.CommentModels
{
    [DataContract]
    public class FavoriteCommentModel : DataModel
    {
        /// <summary>
        /// the id will be used to identifier client and server item
        /// </summary>
        [DataMember(Name = "sid", EmitDefaultValue = false)]
        public string SID { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        [DataMember(Name = "isDeleted", EmitDefaultValue = false)]
        public bool IsDeleted { get; set; }
    }
}
