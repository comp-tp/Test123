using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract]
    public class WSAssetDescription : WSIdentifierBase
    {
        public static WSAssetDescription FromEntityModel(AssetDescriptionModel assetDescriptionModel)
        {
            WSAssetDescription wsAssetDescription = null;
            if (assetDescriptionModel != null)
            { 
                wsAssetDescription = new WSAssetDescription();
                wsAssetDescription.Id = assetDescriptionModel.Identifier;
                wsAssetDescription.Display = assetDescriptionModel.Display;
            }
            return wsAssetDescription;
        }
    }
}
