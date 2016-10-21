using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name="asset")]
    public class WSCAAsset : WSIdentifierBase
    {
        [DataMember(Name = "type", EmitDefaultValue = false, Order = 3)]
        public WSAssetType Type { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false, Order = 4)]
        public WSAssetDescription Description { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false, Order = 5)]
        public string Name { get; set; }

        public static WSCAAsset FromEntityModel(CAAssetModel caAssetModel)
        {
            WSCAAsset wsCAAsset = null;
            if (caAssetModel != null)
            {
                wsCAAsset = new WSCAAsset();
                wsCAAsset.Id = caAssetModel.Identifier;
                wsCAAsset.Display = caAssetModel.Display;
                wsCAAsset.Type = WSAssetType.FromEntityModel(caAssetModel.Type);
                wsCAAsset.Description = WSAssetDescription.FromEntityModel(caAssetModel.Description);
                wsCAAsset.Name = caAssetModel.Name;
            }
            return wsCAAsset;
        }
    }
}
