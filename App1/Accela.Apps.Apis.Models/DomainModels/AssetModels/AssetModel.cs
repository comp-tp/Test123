using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;

namespace Accela.Apps.Apis.Models.DomainModels.AssetModels
{
    /// <summary>
    /// Asset data model
    /// </summary>
    [DataContract]
    public class AssetModel : DataModel, IDataModel
    {
        /// <summary>
        /// Gets or sets the asset Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the asset display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the asset action.
        /// </summary>
        [DataMember(Name = "action", EmitDefaultValue = false)]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the asset comments.
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the asset context type.
        /// </summary>
        [DataMember(Name = "contextType", EmitDefaultValue = false)]
        public string ContextType { get; set; }

        /// <summary>
        /// Gets or sets the asset current value.
        /// </summary>
        [DataMember(Name = "currentValue", EmitDefaultValue = false)]
        public string CurrentValue { get; set; }

        /// <summary>
        /// Gets or sets the date of service.
        /// </summary>
        [DataMember(Name = "dateOfService", EmitDefaultValue = false)]
        public string DateOfService { get; set; }

        /// <summary>
        /// Gets or sets the asset depreciation amount.
        /// </summary>
        [DataMember(Name = "depreciationAmount", EmitDefaultValue = false)]
        public string DepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the asset depreciation value.
        /// </summary>
        [DataMember(Name = "depreciationValue", EmitDefaultValue = false)]
        public string DepreciationValue { get; set; }

        /// <summary>
        /// Gets or sets the asset description.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the asset end date.
        /// </summary>
        [DataMember(Name = "endDate", EmitDefaultValue = false)]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets the asset salvage value.
        /// </summary>
        [DataMember(Name = "salvageValue", EmitDefaultValue = false)]
        public string SalvageValue { get; set; }

        /// <summary>
        /// Gets or sets the asset start date.
        /// </summary>
        [DataMember(Name = "startDate", EmitDefaultValue = false)]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the asset start value.
        /// </summary>
        [DataMember(Name = "startValue", EmitDefaultValue = false)]
        public string StartValue { get; set; }

        /// <summary>
        /// Gets or sets the asset status dates.
        /// </summary>
        [DataMember(Name = "statusDates", EmitDefaultValue = false)]
        public string StatusDates { get; set; }

        /// <summary>
        /// Gets or sets the asset useful life.
        /// </summary>
        [DataMember(Name = "usefulLife", EmitDefaultValue = false)]
        public string UsefulLife { get; set; }

        /// <summary>
        ///  Gets or sets the asset class type.
        /// </summary>
        [DataMember(Name = "classType", EmitDefaultValue = false)]
        public string ClassType { get; set; }

        /// <summary>
        /// Type information of this asset. 
        /// </summary>
        [DataMember(Name = "assetType", EmitDefaultValue = false)]
        public AssetTypeModel AssetType { get; set; }

        /// <summary>
        /// Status information of this asset. 
        /// </summary>
        [DataMember(Name = "assetStatus", EmitDefaultValue = false)]
        public AssetStatusModel AssetStatus { get; set; }

        [DataMember(Name = "assetParent", EmitDefaultValue = false)]
        public AssetParentModel AssetParent { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string AssetName { get; set; }

        public List<AdditionalGroupModel> AdditionalInformation { get; set; }

        public List<AdditionalTableModel> AdditionalTables { get; set; }

        public List<GISObjectModel> GISObjects { get; set; }

        [DataMember(Name = "shortNotes", EmitDefaultValue = false)]
        public string ShortNotes { get; set; }
    }
}
