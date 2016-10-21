using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.GlobalEntityModels
{
    [DataContract(Name = "globalEntityModel")]
    public class GlobalEntityModel
    {
        public const string ENABLED = "1";
        public const string DISABLED = "0";

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid ID { get; set; }

        [DataMember(Name = "entityID", EmitDefaultValue = false)]
        public string EntityID { get; set; }

        [DataMember(Name = "entityType", EmitDefaultValue = false)]
        public string EntityType { get; set; }

        [DataMember(Name = "agencyName", EmitDefaultValue = false)]
        public string AgencyName { get; set; }

        [DataMember(Name = "environment", EmitDefaultValue = false)]
        public string Environment { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        [DataMember(Name = "createdDate", EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "lastUpdatedBy", EmitDefaultValue = false)]
        public string LastUpdatedBy { get; set; }

        [DataMember(Name = "lastUpdatedDate", EmitDefaultValue = false)]
        public DateTime? LastUpdatedDate { get; set; }

        [DataMember(Name = "cloudUserId", EmitDefaultValue = false)]
        public Guid CloudUserID { get; set; }

        [DataMember(Name = "udf1", EmitDefaultValue = false)]
        public string Keep1 { get; set; }

        [DataMember(Name = "udf2", EmitDefaultValue = false)]
        public string Keep2 { get; set; }

        [DataMember(Name = "udf3", EmitDefaultValue = false)]
        public string Keep3 { get; set; }

        [DataMember(Name = "udf4", EmitDefaultValue = false)]
        public string Keep4 { get; set; }

        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public string Latitude { get; set; }

        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public string Longitude { get; set; }

        [DataMember(Name = "openDate", EmitDefaultValue = false)]
        public DateTime? OpenDate { get; set; }

        [DataMember(Name = "imageUrls", EmitDefaultValue = false)]
        public List<string> ImageUrls { get; set; }

        [DataMember(Name = "assignTo", EmitDefaultValue = false)]
        public string AssignTo { get; set; }

        [DataMember(Name = "isPrivate", EmitDefaultValue = false)]
        public bool IsPrivate { get; set; }

        [DataMember(Name = "followersCount", EmitDefaultValue = false)]
        public int FollowersCount { get; set; }
    }
}
