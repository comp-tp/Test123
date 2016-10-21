using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract]
    public class WSGISLayer
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        public static WSGISLayer FromEntityModel(GISLayerModel gisLayerModel)
        {
            WSGISLayer result = null;

            if (gisLayerModel != null)
            {
                result = new WSGISLayer
                {
                    Id = gisLayerModel.Id,
                    Display = gisLayerModel.Display
                };
            }

            return result;
        }
    }

    [DataContract(Name = "assetType")]
    public class WSAssetType : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string Group { get; set; }

        [DataMember(Name = "gisService", EmitDefaultValue = false)]
        public string GISService { get; set; }

        [DataMember(Name = "gisIDForAssetID", EmitDefaultValue = false)]
        public string GISIDForAssetID { get; set; }

        [DataMember(Name = "gisLayer", EmitDefaultValue = false)]
        public WSGISLayer GISLayer { get; set; }

        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="recordStatus">Record status model.</param>
        /// <returns>Web service record status model.</returns>
        public static WSAssetType FromEntityModel(AssetTypeModel assetType)
        {
            if (assetType != null)
            {
                return new WSAssetType()
                {
                    Id = assetType.Id,
                    Display = assetType.Display,
                    Group = assetType.Group,
                    GISIDForAssetID = assetType.GISIDFieldName,
                    GISService = assetType.GISService,
                    GISLayer = WSGISLayer.FromEntityModel(assetType.GISLayer)
                };
            }
            return null;
        }

        public static AssetTypeModel ToEntityModel(WSAssetType wsAssetType)
        {
            AssetTypeModel result = new AssetTypeModel();

            if (wsAssetType != null)
            {
                result.Id = wsAssetType.Id;
                result.Display = wsAssetType.Display;
            }

            return result;
        }
    }
}
