using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "assetCAType")]
    public class WSAssetCAType : WSIdentifierBase
    {
        public static WSAssetCAType FromEntityModel(AssetCATypeModel assetCATypeModel)
        {
            WSAssetCAType wsAssetCAType = null;
            if (assetCATypeModel != null)
            {
                wsAssetCAType = new WSAssetCAType();
                wsAssetCAType.Id = assetCATypeModel.Identifier;
                wsAssetCAType.Display = assetCATypeModel.Display;
            }
            return wsAssetCAType;
        }

        public static AssetCATypeModel ToEntityModel(WSAssetCAType wsAssetCAType)
        {
            AssetCATypeModel assetCATypeModel = null;
            if (wsAssetCAType != null)
            {
                assetCATypeModel = new AssetCATypeModel();
                assetCATypeModel.Identifier = wsAssetCAType.Id;
                assetCATypeModel.Display = wsAssetCAType.Display;
            }
            return assetCATypeModel;
        }
    }
}
