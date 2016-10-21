using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using System.Collections.Generic;
using Accela.Apps.Apis.WSModels.Location;

namespace Accela.Apps.Apis.WSModels.Assets
{
    /// <summary>
    /// Web service Asset data model
    /// </summary>
    [DataContract]
    public class WSAsset : WSEntityState
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

        [DataMember(Name = "assetName", EmitDefaultValue = false)]
        public string AssetName { get; set; }

        /// <summary>
        /// Type information of this asset. 
        /// </summary>
        [DataMember(Name = "assetType", EmitDefaultValue = false)]
        public WSAssetType AssetType { get; set; }

        /// <summary>
        /// Status information of this asset. 
        /// </summary>
        [DataMember(Name = "assetStatus", EmitDefaultValue = false)]
        public WSAssetStatus AssetStatus { get; set; }

        [DataMember(Name = "gisObjects", EmitDefaultValue = false)]
        public List<WSGISObject> GisObjects { get; set; }

        /// <summary>
        /// Parent of this asset. 
        /// </summary>
        [DataMember(Name = "assetParent", EmitDefaultValue = false)]
        public WSAssetParent AssetParent { get; set; }

        [DataMember(Name = "shortNotes", EmitDefaultValue = false)]
        public string ShortNotes { get; set; }

        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="record">Record model.</param>
        /// <returns>Web service record model.</returns>
        public static WSAsset FromEntityModel(AssetModel asset)
        {
            if (asset != null)
            {
                return new WSAsset()
                {
                    Id = asset.Id,
                    Display = asset.Display,
                    Description = asset.Description,
                    AssetType = WSAssetType.FromEntityModel(asset.AssetType),
                    AssetStatus = WSAssetStatus.FromEntityModel(asset.AssetStatus),
                    EntityState = WSEntityState.ConvertActionToEntityState(asset.Action),
                    Comments = asset.Comments,
                    ContextType = asset.ContextType,
                    CurrentValue = asset.CurrentValue,
                    DateOfService = asset.DateOfService,
                    DepreciationAmount = asset.DepreciationAmount,
                    DepreciationValue = asset.DepreciationValue,
                    EndDate = asset.EndDate,
                    SalvageValue = asset.SalvageValue,
                    StartDate = asset.StartDate,
                    StartValue = asset.StartValue,
                    StatusDates = asset.StatusDates,
                    UsefulLife = asset.UsefulLife,
                    ClassType = asset.ClassType,
                    AssetName = asset.AssetName,
                    GisObjects = WSGISObject.FromEntityModels(asset.GISObjects),
                    AssetParent = WSAssetParent.FromEntityModel(asset.AssetParent),
                    ShortNotes = asset.ShortNotes
                };
            }
            return null;
        }

        public static AssetModel ToEntityModel(WSAsset wsAsset)
        {
            if (wsAsset != null)
            {
                return new AssetModel()
                {
                    Id = wsAsset.Id,
                    Display = wsAsset.Display,
                    Description = wsAsset.Description,
                    AssetType = WSAssetType.ToEntityModel(wsAsset.AssetType),
                    AssetStatus = WSAssetStatus.ToEntityModel(wsAsset.AssetStatus),
                    Action = WSEntityState.ConvertEntityStateToAction(wsAsset.EntityState),
                    Comments = wsAsset.Comments,
                    AssetName = wsAsset.AssetName,
                    ContextType = wsAsset.ContextType,
                    CurrentValue = wsAsset.CurrentValue,
                    DateOfService = wsAsset.DateOfService,
                    DepreciationAmount = wsAsset.DepreciationAmount,
                    DepreciationValue = wsAsset.DepreciationValue,
                    EndDate = wsAsset.EndDate,
                    SalvageValue = wsAsset.SalvageValue,
                    StartDate = wsAsset.StartDate,
                    StartValue = wsAsset.StartValue,
                    StatusDates = wsAsset.StatusDates,
                    UsefulLife = wsAsset.UsefulLife,
                    ClassType = wsAsset.ClassType,
                    AssetParent = WSAssetParent.ToEntityModel(wsAsset.AssetParent)
                };
            }
            return null;
        }
    }
}
