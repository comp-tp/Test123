using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class AssetCriteria
    {
        /// <summary>
        /// this is asset display
        /// if we have asset ids, then the field will be ignore
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Search by asset Ids
        /// </summary>
        [DataMember(Name = "assetIds", EmitDefaultValue = false)]
        public List<string> AssetIds { get; set; }

        /// <summary>
        /// Search by asset Type Ids
        /// </summary>
        [DataMember(Name = "assetTypeIds", EmitDefaultValue = false)]
        public List<string> AssetTypeIds { get; set; }

        /// <summary>
        /// Search By asset Status Ids
        /// </summary>
        [DataMember(Name = "assetStatus", EmitDefaultValue = false)]
        public string AssetStatus { get; set; }

        /// <summary>
        /// Search by asset description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Search by asset comments
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        /// <summary>
        /// Search by asset comments
        /// </summary>
        [DataMember(Name = "currentValueFrom", EmitDefaultValue = false)]
        public string CurrentValueFrom { get; set; }

        /// <summary>
        /// Search by asset comments
        /// </summary>
        [DataMember(Name = "currentValueTo", EmitDefaultValue = false)]
        public string CurrentValueTo { get; set; }

        /// <summary>
        /// Search by asset comments
        /// </summary>
        [DataMember(Name = "statusDateFrom", EmitDefaultValue = false)]
        public string StatusDateFrom { get; set; }

        /// <summary>
        /// Search by asset comments
        /// </summary>
        [DataMember(Name = "statusDateValueTo", EmitDefaultValue = false)]
        public string StatusDateTo { get; set; }

        /// <summary>
        /// Search by asset comments
        /// </summary>
        [DataMember(Name = "dateOfServiceFrom", EmitDefaultValue = false)]
        public string DateOfServiceFrom { get; set; }

        /// <summary>
        /// Search by asset comments
        /// </summary>
        [DataMember(Name = "dateOfServiceTo", EmitDefaultValue = false)]
        public string DateOfServiceTo { get; set; }

        public AssetDetailAddress DetailAddress { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }
    }

    public class AssetDetailAddress
    {
        /// <summary>
        /// House number.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Street name
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// ZipCode.
        /// </summary>
        public string ZipCode { get; set; }
    }
}
