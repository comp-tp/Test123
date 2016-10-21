using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    public class WSCreateAsset : WSAsset
    {
        public static AssetModel ToEntityModel(WSCreateAsset wsCreateAsset)
        {
            if (wsCreateAsset != null)
            {
                AssetModel assetModel = new AssetModel();
            }

            return null;
        }
    }
}
