using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "createAssetRequest")]
    public class WSCreateAssetRequest
    {
        [DataMember(Name = "createAsset", EmitDefaultValue = false)]
        public WSCreateAsset CreateAsset { get; set; }

        public static void ToEntityModel(CreateAssetRequest createAssetRequest, WSCreateAssetRequest wsCreateAssetRequest)
        {
            if (wsCreateAssetRequest == null)
            {
                return;
            }

            if (wsCreateAssetRequest.CreateAsset == null)
            {
                return;
            }

            if (createAssetRequest == null)
            {
                return;
            }

            if (createAssetRequest.Asset == null)
            {
                createAssetRequest.Asset = new AssetModel();
            }

            createAssetRequest.Asset.Id = wsCreateAssetRequest.CreateAsset.Id;
            createAssetRequest.Asset.Display = wsCreateAssetRequest.CreateAsset.Display;
            createAssetRequest.Asset.Comments = wsCreateAssetRequest.CreateAsset.Comments;
            createAssetRequest.Asset.ContextType = wsCreateAssetRequest.CreateAsset.ContextType;
            createAssetRequest.Asset.CurrentValue = wsCreateAssetRequest.CreateAsset.CurrentValue;
            createAssetRequest.Asset.DateOfService = wsCreateAssetRequest.CreateAsset.DateOfService;
            createAssetRequest.Asset.DepreciationAmount = wsCreateAssetRequest.CreateAsset.DepreciationAmount;
            createAssetRequest.Asset.DepreciationValue = wsCreateAssetRequest.CreateAsset.DepreciationValue;
            createAssetRequest.Asset.Description = wsCreateAssetRequest.CreateAsset.Description;
            createAssetRequest.Asset.EndDate = wsCreateAssetRequest.CreateAsset.EndDate;
            createAssetRequest.Asset.SalvageValue = wsCreateAssetRequest.CreateAsset.SalvageValue;
            createAssetRequest.Asset.StartDate = wsCreateAssetRequest.CreateAsset.StartDate;
            createAssetRequest.Asset.StartValue = wsCreateAssetRequest.CreateAsset.StartValue;
            createAssetRequest.Asset.StatusDates = wsCreateAssetRequest.CreateAsset.StatusDates;
            createAssetRequest.Asset.UsefulLife = wsCreateAssetRequest.CreateAsset.UsefulLife;
            createAssetRequest.Asset.AssetType = WSAssetType.ToEntityModel(wsCreateAssetRequest.CreateAsset.AssetType);
            createAssetRequest.Asset.AssetStatus = WSAssetStatus.ToEntityModel(wsCreateAssetRequest.CreateAsset.AssetStatus);
        }
    }
}
