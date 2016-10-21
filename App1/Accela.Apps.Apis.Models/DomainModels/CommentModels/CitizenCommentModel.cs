using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.CommentModels
{
    [DataContract]
    public class CitizenCommentModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid ID {get; set;}

        [DataMember(Name = "globalEntityID", EmitDefaultValue = false)]
        public Guid GlobalEntityID { get; set; }

        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string Comment { get; set; }

        [DataMember(Name = "appID", EmitDefaultValue = false)]
        public string AppID { get; set; }

        [DataMember(Name = "cloudUserId", EmitDefaultValue = false)]
        public Guid CloudUserId { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        [DataMember(Name = "createdDate", EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "lastUpdatedBy", EmitDefaultValue = false)]
        public string LastUpdatedBy { get; set; }

        [DataMember(Name = "lastUpdatedDate", EmitDefaultValue = false)]
        public DateTime LastUpdatedDate { get; set; }

        [DataMember(Name = "userProfilePictureUrl", EmitDefaultValue = false, Order = 5)]
        public string UserProfilePictureUrl { get; set; } 
    }
}
