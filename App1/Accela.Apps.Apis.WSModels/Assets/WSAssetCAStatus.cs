using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "assetCAStatus")]
    public class WSAssetCAStatus : WSIdentifierBase
    {
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 3)]
        public string Name { get; set; }

        public static WSAssetCAStatus FromEntityModel(AssetCAStatusModel assetCAStatusModel)
        {
            WSAssetCAStatus wsAssetCAStatus = null;
            if (assetCAStatusModel != null)
            {
                wsAssetCAStatus = new WSAssetCAStatus();
                wsAssetCAStatus.Id = assetCAStatusModel.Identifier;
                wsAssetCAStatus.Display = assetCAStatusModel.Display;
                wsAssetCAStatus.Name = assetCAStatusModel.Name;
            }
            return wsAssetCAStatus;
        }

        public static AssetCAStatusModel ToEntityModel(WSAssetCAStatus wsAssetCAStatus)
        {
            AssetCAStatusModel assetCAStatusModel = null;
            if (wsAssetCAStatus != null)
            {
                assetCAStatusModel = new AssetCAStatusModel();
                assetCAStatusModel.Identifier = wsAssetCAStatus.Id;
                assetCAStatusModel.Display = wsAssetCAStatus.Display;
                assetCAStatusModel.Name = wsAssetCAStatus.Name;
            }
            return assetCAStatusModel;
        }
    }
}
